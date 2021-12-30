using CSharpFunctionalExtensions;

namespace Emma.Api.Controllers
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Maybe<Employee>> GetById(int id);
        Task<Result<Employee, RepositoryError>> Create(Employee employee);
        Task<Result<Employee, RepositoryError>> Update(Employee employee);
        Task Delete(int id);
    }

    public enum RepositoryError
    {
        NotFound,
    }
}
