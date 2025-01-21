using Core.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task<UserModel?> CreateUserAsync(string username, string password, CancellationToken cancellationToken);
    }
}
