using CSharpFunctionalExtensions;

namespace Emma.Api.Controllers
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Maybe<Employee>> GetById(int id);
        Task<Result<Employee>> Create(Employee employee);
    }
}
