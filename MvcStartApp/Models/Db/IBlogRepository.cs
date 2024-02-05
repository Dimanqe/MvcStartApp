using System.Threading.Tasks;

namespace MvcStartApp.Models.Db
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
