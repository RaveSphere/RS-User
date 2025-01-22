using Application.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class UserService(IUserSqlRepository userSqlRepository) : IUserService
    {
        public async Task<CreateUserModel?> CreateUserAsync(string username, string hashedPassword, Guid salt, CancellationToken cancellationToken)
        {
            if (await userSqlRepository.CheckIfUserExistsAsync(username, cancellationToken))
            {
                return null;
            }

            CreateUserModel user = new CreateUserModel(username, hashedPassword, salt.ToByteArray());
            return await userSqlRepository.SaveUserAsync(user, cancellationToken);
        }

        public async Task<GetUserModel?> GetUserAsync(string username, CancellationToken cancellationToken)
        {
            return await userSqlRepository.GetUserAsync(username, cancellationToken);
        }

        public async Task<GetUserSaltModel?> GetUserSaltAsync(string username, CancellationToken cancellationToken)
        {
            return await userSqlRepository.GetUserSaltAsync(username, cancellationToken);
        }

        public async Task<GetUserModel?> ValidateCredentialsAsync(string username, string password, CancellationToken cancellationToken)
        {
            if (!await userSqlRepository.ValidateCredentialsAsync(username, password, cancellationToken))
            {
                return null;
            }

            return await GetUserAsync(username, cancellationToken);
        }
    }
}
