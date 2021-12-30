using CSharpFunctionalExtensions;

namespace Emma.Api.Controllers
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Maybe<Employee> GetById(int id);
    }
}
