using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("[action]")]
        [HttpGet]
        public string GetName()
        {
            return "Test";
        }

        [Route("GetFullNAme")]
        [HttpGet]
        public string GetFullName()
        {
            return "Test Name";
        }
    }
}
