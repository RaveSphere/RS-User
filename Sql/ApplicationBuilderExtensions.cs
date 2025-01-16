using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sql.Contexts;

namespace Sql
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            app.ApplyMigrations<UserDbContext>();
        }

        public static void ApplyMigrations<T>(this IApplicationBuilder app) where T : DbContext
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                DbContext db = scope.ServiceProvider.GetRequiredService<T>();
                db.Database.Migrate();
            }
        }
    }
}
