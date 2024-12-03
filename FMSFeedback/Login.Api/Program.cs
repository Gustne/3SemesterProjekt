using Login.Application;
using Login.Application.Queries;
using Login.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationDependency();
builder.Services.AddInfrastructureDependency(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Activities/Exit", (Guid guid, IActivityQuery query) => query.GetExitActivities(guid));
app.MapGet("/Activities/Forum", (Guid guid, IActivityQuery query) => query.GetForumActivities(guid));

app.MapGet("/Students", (int activityId, IPersonQuery query) => query.GetPeople(activityId));




app.Run();

