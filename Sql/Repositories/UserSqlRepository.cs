using Application.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sql.Contexts;
using Sql.Entities;
using Sql.Mappers;

namespace Sql.Repositories
{
    internal class UserSqlRepository(UserDbContext userContext, ILogger<UserSqlRepository> logger) : IUserSqlRepository
    {
        public async Task<CreateUserModel?> SaveUserAsync(CreateUserModel user, CancellationToken cancellationToken)
        {
            await userContext.AddAsync(UserMapper.Map(user), cancellationToken);

            try
            {
                await userContext.SaveChangesAsync(cancellationToken);
                return user;
            }
            catch (DbUpdateException exception)
            {
                logger.LogError(exception, "Could not save to DB");
                return null;
            }
        }

        public async Task<GetUserModel?> GetUserAsync(string username, CancellationToken cancellationToken)
        {
            UserEntity? userEntity = await userContext.UserEntities.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);

            return userEntity == null ? null : UserMapper.Map(userEntity);
        }

        public async Task<GetUserSaltModel?> GetUserSaltAsync(string username, CancellationToken cancellationToken)
        {
            UserEntity? userEntity = await userContext.UserEntities.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);

            return userEntity == null ? null : UserMapper.SaltMap(userEntity);
        }

        public async Task<bool> CheckIfUserExistsAsync(string username, CancellationToken cancellationToken)
        {
            return await userContext.UserEntities.AnyAsync(x => x.Username == username, cancellationToken);
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password, CancellationToken cancellationToken)
        {
            return await userContext.UserEntities.AnyAsync(x => x.Username == username && x.Password == password, cancellationToken);
        }
    }
}
