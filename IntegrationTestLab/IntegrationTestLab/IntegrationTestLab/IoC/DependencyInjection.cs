using IntegrationTestLab.Domain.Interfaces;
using IntegrationTestLab.Infra;
using IntegrationTestLab.Services;

namespace IntegrationTestLab.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<UserService, UserService>();
            services.AddScoped<IEmailNotifier, EmailNotifier>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
