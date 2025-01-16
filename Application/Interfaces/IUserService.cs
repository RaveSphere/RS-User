using Core.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task<User> CreateUserAsync(string username, string password, CancellationToken cancellationToken);
    }
}
