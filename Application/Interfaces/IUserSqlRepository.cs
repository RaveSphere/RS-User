using Core.Models;

namespace Application.Interfaces
{
    public interface IUserSqlRepository
    {
        public Task<User?> SaveUserAsync(User user, CancellationToken cancellationToken);
        public Task<User?> GetUserAsync(string username, CancellationToken cancellationToken);
    }
}
