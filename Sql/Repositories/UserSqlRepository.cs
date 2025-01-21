using Application.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sql.Contexts;
using Sql.Entities;

namespace Sql.Repositories
{
    internal class UserSqlRepository(UserDbContext userContext, ILogger<UserSqlRepository> logger) : IUserSqlRepository
    {
        public async Task<UserModel?> SaveUserAsync(UserModel user, CancellationToken cancellationToken)
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

        public async Task<UserModel?> GetUserAsync(string username, CancellationToken cancellationToken)
        {
            UserEntity? userEntity = await userContext.UserEntities.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);

            return userEntity == null ? null : UserMapper.Map(userEntity);
        }
    }
}
