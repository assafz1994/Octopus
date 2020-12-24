using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OctopusCore;

namespace CommunicationLayer.Controllers
{
    [ApiController]
    public class ExecuteQueryController : ControllerBase
    {
        private readonly IOctopusService _octopusService;
        public ExecuteQueryController(IOctopusService octopusService)
        {
            _octopusService = octopusService;
        }


        [HttpGet]
        [HttpPost]
        [Route("ExecuteQuery")]
        //Example: https://localhost:44398/executequery/?query=from Person u | where u.Name == Assaf |select u(Name,Age)
        public async Task<string> ExecuteQueryAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return string.Empty;
            }

            var result = await _octopusService.ExecuteQueryAsync(query);

            return result;
        }
    }
}