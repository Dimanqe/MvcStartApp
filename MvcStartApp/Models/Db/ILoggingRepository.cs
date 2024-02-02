using System.Threading.Tasks;

namespace MvcStartApp.Models.Db
{
    public interface ILoggingRepository
    {
        Task AddRequest(Request request);

        Task<Request[]> GetRequests();
    }
}
