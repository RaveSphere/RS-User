using Core.Models;

namespace Application.Interfaces
{
    public interface IUserSqlRepository
    {
        Task<CreateUserModel?> SaveUserAsync(CreateUserModel user, CancellationToken cancellationToken);
        Task<GetUserModel?> GetUserAsync(string username, CancellationToken cancellationToken);
        Task<bool> CheckIfUserExistsAsync(string username, CancellationToken cancellationToken);
        Task<GetUserSaltModel?> GetUserSaltAsync(string username, CancellationToken cancellationToken);
        Task<bool> ValidateCredentialsAsync(string username, string password, CancellationToken cancellationToken);
    }
}
