﻿using Login.Application.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Login.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
    {




        // Add-Migration InitialMigration -Context LoginContext -Project Login.DatabaseMigration
        // Update-Database -Context LoginContext -Project Login.DatabaseMigration

        services.AddDbContext<LoginContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("LoginConnection"),
            x => x.MigrationsAssembly("Login.DatabaseMigration")));

        services.AddScoped<IUnitOfWork, UnitOfWork>(p =>
        {
            var db = p.GetService<LoginContext>();
            return new UnitOfWork(db);
        });

        return services;
    }
}