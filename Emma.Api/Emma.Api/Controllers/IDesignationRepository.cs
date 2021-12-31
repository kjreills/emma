namespace Emma.Api.Controllers
{
    public interface IDesignationRepository
    {
        Task<IEnumerable<Designation>> GetAll();
    }
}
