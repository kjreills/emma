using Emma.Api.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Emma.Api.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeContext _employeeContext;

        public DepartmentRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _employeeContext.Department!
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
