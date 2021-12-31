using Emma.Api.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Emma.Api.Repositories
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly EmployeeContext _employeeContext;

        public DesignationRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public async Task<IEnumerable<Designation>> GetAll()
        {
            return await _employeeContext.Designation!
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
