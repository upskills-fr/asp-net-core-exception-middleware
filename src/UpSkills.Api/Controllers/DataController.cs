using Microsoft.AspNetCore.Mvc;
using UpSkills.Api.Exceptions;

namespace UpSkills.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet("")]
        public IAsyncResult Get()
        {
            throw new AlgoComputeException("Algo Compute Exception Message", new AlgoComputeErrorDetails("data1", 1));
        }
    }
}
