using Api.Mappers;
using Api.RequestModels;
using Application.Interfaces;
using Core.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService, IValidator<CreateUserRequest> validator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request, CancellationToken cancellationToken = default)
        {
            ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            UserModel? user = await userService.CreateUserAsync(request.Username, request.Password, cancellationToken);

            if (user == null)
            {
                return BadRequest("Could not create user");
            }

            return Ok(UserMapper.Map(user));
        }
    }
}
