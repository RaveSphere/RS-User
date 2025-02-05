using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sql.Contexts;
using Sql.Repositories;

namespace Sql
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserServiceDb(this IServiceCollection services, IConfiguration configuration, string? environment)
        {
            string? connectionString;

            if (environment == "Production")
            {
                var vaultService = services.BuildServiceProvider().GetRequiredService<IVaultService>();
                connectionString = vaultService.GetSecretAsync("userService/connectionStrings", "UserServiceDb").Result;
            }
            else
            {
                connectionString = configuration.GetConnectionString("UserServiceDb");
            }

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
