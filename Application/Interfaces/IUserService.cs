using Core.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserModel?> CreateUserAsync(string username, string hasedPassword, Guid salt, CancellationToken cancellationToken);
        Task<GetUserModel?> GetUserAsync(string username, CancellationToken cancellationToken);
        Task<GetUserSaltModel?> GetUserSaltAsync(string username, CancellationToken cancellationToken);
        Task<GetUserModel?> ValidateCredentialsAsync(string username, string password, CancellationToken cancellationToken);
    }
}
