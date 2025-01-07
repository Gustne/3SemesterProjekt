using ExitSlip.Application;
using ExitSlip.Application.Helpers;
using ExitSlip.Application.Queries;
using ExitSlip.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExitSlip.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IExitQuery, ExitQuery>();

        services.AddScoped<IExitRepository, ExitRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();

        // Add-Migration InitialMigration -Context ExitSlipContext -Project ExitSLip.DatabaseMigration
        // Update-Database -Context ExitSlipContext -Project ExitSlip.DatabaseMigration

        services.AddDbContext<ExitSlipContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("ExitSlipDbConnection"),
                x => x.MigrationsAssembly("ExitSlip.DatabaseMigration")));

        services.AddScoped<IUnitOfWork, UnitOfWork>(p =>
        {
            var db = p.GetService<ExitSlipContext>();
            return new UnitOfWork(db);
        });


        return services;
    }
}