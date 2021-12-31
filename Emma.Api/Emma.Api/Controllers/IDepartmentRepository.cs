namespace Emma.Api.Controllers
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAll();
    }
}
