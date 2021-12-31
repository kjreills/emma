using CSharpFunctionalExtensions;
using Emma.Api.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Emma.Api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public async Task<Result<Employee, RepositoryError>> Create(Employee employee)
        {
            if (_employeeContext.Employee == null
                || _employeeContext.Department == null
                || _employeeContext.Designation == null)
            {
                return Result.Failure<Employee, RepositoryError>(RepositoryError.ConfigurationError);
            }

            var created = _employeeContext.Employee.Update(employee with { Id = 0 });
            await _employeeContext.SaveChangesAsync();

            return Result.Success<Employee, RepositoryError>(created.Entity);
        }

        public async Task<Result<int,RepositoryError>> Delete(int id)
        {
            if (_employeeContext.Employee == null)
            {
                return Result.Failure<int, RepositoryError>(RepositoryError.ConfigurationError);
            }

            var employee = await GetById(id);

            if (employee.HasValue)
            {
                _employeeContext.Employee.Remove(employee.Value);
                await _employeeContext.SaveChangesAsync();
            }

            return Result.Success<int, RepositoryError>(id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _employeeContext.Employee!
                .AsNoTracking()
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .ToListAsync();
        }

        public async Task<Maybe<Employee>> GetById(int id)
        {
            var employee = await _employeeContext.Employee!
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .FirstOrDefaultAsync(x => x.Id == id);

            return employee != null ? Maybe.From(employee) : Maybe.None;
        }

        public async Task<Result<Employee, RepositoryError>> Update(Employee employee)
        {
            var result = _employeeContext.Employee!.Update(employee);

            await _employeeContext.SaveChangesAsync();

            if (result != null)
            {
                return Result.Success<Employee, RepositoryError>(result.Entity);
            }

            return Result.Failure<Employee, RepositoryError>(RepositoryError.ConfigurationError);
        }
    }
}
