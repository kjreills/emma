using CSharpFunctionalExtensions;
using Emma.Api.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Emma.Api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository()
        {

        }

        public Task<Result<Employee, RepositoryError>> Create(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Maybe<Employee>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Employee, RepositoryError>> Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }

    public class EmployeeContext : DbContext
    {

    }
}
