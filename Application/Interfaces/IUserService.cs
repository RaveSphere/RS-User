using Core.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task<UserModel?> CreateUserAsync(string username, string hasedPassword, Guid salt, CancellationToken cancellationToken);
    }
}
