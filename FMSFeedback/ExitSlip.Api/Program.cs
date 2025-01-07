using ExitSlip.Application;
using ExitSlip.Application.Command.CommandDto;
using ExitSlip.Application.Command.Interfaces;
using ExitSlip.Application.Queries;
using ExitSlip.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddInfrastructureDependency(builder.Configuration);
builder.Services.AddApplicationDependency();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/Exit", (CreateExitDto exit, IExitCommand command) => command.CreateExit(exit));
app.MapPost("/Question", (CreateQuestionDto question, IExitCommand command) => command.CreateQuestion(question));
app.MapPost("/Answer", (CreateAnswerDto answer, IQuestionCommand command) => command.CreateAnswer(answer));

app.MapGet("/Exit/overview", (int activityId, IExitQuery query) => query.GetExitOverview(activityId));
app.MapGet("/Exit/Detailed", (int ExitId, IExitQuery query) => query.GetDetailedExit(ExitId));
app.MapGet("/Exit/Personal", (int activityId, Guid userGuid, IExitQuery query) => query.GetPersonalExit(activityId, userGuid));


app.Run();
