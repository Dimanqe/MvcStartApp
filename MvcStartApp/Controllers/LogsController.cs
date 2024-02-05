using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        private ILoggingRepository _loggerRepository;

        public LogsController(ILoggingRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }
        
        public async Task<IActionResult> Request()
        {
            var requests = await _loggerRepository.GetRequests();
            return View(requests);
        }        
        
    }
}
