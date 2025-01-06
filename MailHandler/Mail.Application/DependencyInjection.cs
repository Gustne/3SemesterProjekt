using System;

public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    services.AddScoped<IMailRepository, ProductRepository>();
    services.AddScoped<IEmailService, EmailService>();

    services.AddControllers();
}}
}
