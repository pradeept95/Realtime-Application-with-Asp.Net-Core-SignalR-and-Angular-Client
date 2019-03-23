using System.Linq;
using AspDotNetCoreSignalRWithAngular.Host.DataManagers;
using AspDotNetCoreSignalRWithAngular.Host.Hubs;
using AspDotNetCoreSignalRWithAngular.Host.TimerManagers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AspDotNetCoreSignalRWithAngular.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPUController : ControllerBase
    {
        private IHubContext<ChartHub> _hub;

        public CPUController(IHubContext<ChartHub> hub)
        {
            _hub = hub;
        }

        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transfercpudata", DataManager.GetCPUData()));
            return Ok(new { Message = "Request Completed" });
        }
    }
}
