using Application.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class UserService(IUserSqlRepository userSqlRepository, IHashingService hashingService) : IUserService
    {
        public async Task<UserModel?> CreateUserAsync(string username, string password, CancellationToken cancellationToken)
        {
            if (await userSqlRepository.GetUserAsync(username, cancellationToken) != null)
            {
                return null;
            }

            HashingModel hashingModel = await hashingService.Hash(password, Guid.NewGuid().ToByteArray());

            UserModel user = new UserModel(username, hashingModel.HashedPassword, hashingModel.Salt);
            return await userSqlRepository.SaveUserAsync(user, cancellationToken);
        }
    }
}
