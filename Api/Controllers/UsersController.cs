using Api.RequestModels;
using Application.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request, CancellationToken cancellationToken = default)
        {
            User? user = await userService.CreateUserAsync(request.Username, request.Password, cancellationToken);
            return Ok(user);
        }
    }
}
