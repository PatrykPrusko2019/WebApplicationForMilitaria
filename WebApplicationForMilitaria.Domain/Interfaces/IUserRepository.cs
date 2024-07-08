
namespace WebApplicationForMilitaria.Domain.Interfaces
{
    public interface IUserRepository
    {
       Task CreateRole();
       Task<string> getRole(string email);
    }
}
