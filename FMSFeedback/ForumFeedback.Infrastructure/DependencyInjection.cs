using ForumFeedback.Application;
using ForumFeedback.Application.Helpers;
using ForumFeedback.Application.Queries;
using ForumFeedback.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ForumFeedback.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IPostQuery, PostQuery>();

        services.AddScoped<IPostRepository, PostRepository>();


        // Add-Migration InitialMigration -Context ForumFeedbackContext -Project ForumFeedback.DatabaseMigration
        // Update-Database -Context ForumFeedbackContext -Project ForumFeedback.DatabaseMigration

        services.AddDbContext<ForumFeedbackContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("ForumFeedbackDbConnection"),
                x => x.MigrationsAssembly("ForumFeedback.DatabaseMigration")));

        services.AddScoped<IUnitOfWork, UnitOfWork>(p =>
        {
            var db = p.GetService<ForumFeedbackContext>();
            return new UnitOfWork(db);
        });


        return services;
    }
}