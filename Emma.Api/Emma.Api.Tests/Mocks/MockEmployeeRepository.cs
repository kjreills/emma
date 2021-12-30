using CSharpFunctionalExtensions;
using Emma.Api.Controllers;

namespace Emma.Api.Tests.Mocks
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        public Dictionary<int, Employee> Employees { get; private set; } = new Dictionary<int, Employee>();

        public MockEmployeeRepository()
        {
        }

        public MockEmployeeRepository(IEnumerable<Employee> employees)
        {
            Setup(employees);
        }

        public void Setup(IEnumerable<Employee> employees)
        {
            Employees = employees.ToDictionary(x => x.Id);
        }

        public void Clear()
        {
            Employees.Clear();
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            return Task.FromResult(Employees.Values.AsEnumerable());
        }

        public Task<Maybe<Employee>> GetById(int id)
        {
            if (Employees.ContainsKey(id))
            {
                return Task.FromResult(Maybe.From(Employees[id]));
            }

            return Task.FromResult(Maybe<Employee>.None);
        }

        public Task<Result<Employee, RepositoryError>> Create(Employee employee)
        {
            var nextKey = Employees.Any() ? Employees.Keys.Max() + 1 : 1;

            var create = employee with { Id = nextKey };

            Employees.Add(nextKey, create);

            return Task.FromResult(Result.Success<Employee, RepositoryError>(create));
        }

        public Task<Result<Employee, RepositoryError>> Update(Employee employee)
        {
            if (Employees.ContainsKey(employee.Id))
            {
                Employees[employee.Id] = employee;

                return Task.FromResult(Result.Success<Employee, RepositoryError>(employee));
            }

            return Task.FromResult(Result.Failure<Employee, RepositoryError>(RepositoryError.NotFound));
        }

        public Task Delete(int id)
        {
            if (Employees.ContainsKey(id))
            {
                Employees.Remove(id);
            }

            return Task.CompletedTask;
        }
    }
}
