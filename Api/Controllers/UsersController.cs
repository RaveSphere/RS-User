using Api.Mappers;
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
            UserModel? user = await userService.CreateUserAsync(request.Username, request.HashedPassword, request.Salt, cancellationToken);

            if (user == null)
            {
                return BadRequest("Could not create user");
            }

            return Ok(UserMapper.Map(user));
        }
    }
}
