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

        public IEnumerable<Employee> GetAll()
        {
            return Employees.Values;
        }

        public Maybe<Employee> GetById(int id)
        {
            if (Employees.ContainsKey(id))
            {
                return Maybe.From(Employees[id]);
            }

            return Maybe.None;
        }
    }
}
