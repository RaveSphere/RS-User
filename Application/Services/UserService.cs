using Application.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class UserService : IUserService
    {
        public Task<User> CreateUserAsync(string username, string password, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
