using Core.Models;

namespace Application.Interfaces
{
    public interface IUserSqlRepository
    {
        public Task<UserModel?> SaveUserAsync(UserModel user, CancellationToken cancellationToken);
        public Task<UserModel?> GetUserAsync(string username, CancellationToken cancellationToken);
    }
}
