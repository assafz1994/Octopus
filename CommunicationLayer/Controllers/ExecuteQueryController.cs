using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CommunicationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExecuteQueryController : ControllerBase
    { 
        //private readonly OctopusService _octopusService;
        public ExecuteQueryController()
        {
        }

        [HttpGet]
        public void Get()
        {
        }

        [HttpGet]
        [Route("ExecuteQuery")]
        //Example: https://localhost:44398/executequery/ExecuteQuery?query=blabla
        public string ExecuteQuery(string query)
        {
           // Task resQuery = _octopusService.ExecuteQuery(query);
            return query;
        }
    }
}
