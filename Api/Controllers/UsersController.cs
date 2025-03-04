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
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request, CancellationToken cancellationToken = default)
        {
            CreateUserModel? user = await userService.CreateUserAsync(request.Username, request.Password, request.Salt, cancellationToken);

            if (user == null)
            {
                return BadRequest("Could not create user");
            }

            return Ok(UserMapper.Map(user));
        }

        [HttpPost("get-user")]
        public async Task<IActionResult> GetUser(GetUserRequest request, CancellationToken cancellationToken = default)
        {
            GetUserModel? user = await userService.GetUserAsync(request.Username, cancellationToken);

            if (user == null)
            {
                return BadRequest("Could not get user");
            }

            return Ok(UserMapper.Map(user));
        }

        [HttpPost("get-user-salt")]
        public async Task<IActionResult> GetUserSalt(GetUserRequest request, CancellationToken cancellationToken = default)
        {
            GetUserSaltModel? salt = await userService.GetUserSaltAsync(request.Username, cancellationToken);

            if (salt == null)
            {
                return BadRequest("Could not find salt");
            }

            return Ok(UserMapper.Map(salt));
        }

        [HttpPost("validate-credentials")]
        public async Task<IActionResult> ValidateCredentials(ValidateCredentialsRequest request, CancellationToken cancellationToken = default)
        {
            GetUserModel? user = await userService.ValidateCredentialsAsync(request.Username, request.Password, cancellationToken);

            if (user == null)
            {
                return BadRequest("Could not validate credentials");
            }

            return Ok(UserMapper.Map(user));
        }
    }
}
