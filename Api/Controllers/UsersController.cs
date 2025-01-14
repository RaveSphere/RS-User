using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPut]
        public IActionResult CreateUser()
        {
            return Ok();
        }
    }
}
