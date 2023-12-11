using FluentValidation;
using Infrastructure.Authentication;
using Infrastructure.Database;
using Infrastructure.Database.DatabaseHelpers;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MockDatabase>();
            services.AddSingleton<JwtTokenGenerator>();
            services.AddDbContext<RealDatabase>(options =>
            {
                //Byt connectionstring så det passar med lokala datorn
                options.UseSqlServer("connectionString").AddInterceptors(new CommandLoggingInterceptor());
            });

            return services;
        }
    }
}