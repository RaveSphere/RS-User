using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sql.Contexts;
using Sql.Repositories;

namespace Sql
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserServiceDb(this IServiceCollection services, string connectionString)
        {
            return services
                .AddScoped<IUserSqlRepository, UserSqlRepository>()
                .AddDbContext<UserDbContext>(options =>
                {
                    options.UseSqlServer(connectionString,
                    x => x.MigrationsAssembly(typeof(UserDbContext).Assembly.GetName().FullName));
                });
        }
    }
}
