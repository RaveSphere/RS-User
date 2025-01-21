using Application.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class UserService(IUserSqlRepository userSqlRepository) : IUserService
    {
        public async Task<UserModel?> CreateUserAsync(string username, string hashedPassword, Guid salt, CancellationToken cancellationToken)
        {
            if (await userSqlRepository.GetUserAsync(username, cancellationToken) != null)
            {
                return null;
            }

            UserModel user = new UserModel(username, hashedPassword, salt.ToByteArray());
            return await userSqlRepository.SaveUserAsync(user, cancellationToken);
        }
    }
}
