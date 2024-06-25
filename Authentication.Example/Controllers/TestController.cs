using Authentication.Example.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = RoleNames.Moderator)]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }


        [HttpPost]
        [Authorize(Roles = RoleNames.Administrator)]
        public IActionResult Post()
        {
            return Ok("Posted");
        }
    }
}
