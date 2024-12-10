using System.Diagnostics;
using ForumFeedback.Application;
using ForumFeedback.Application.Command.CommandDto;
using ForumFeedback.Application.Command.Interfaces;
using ForumFeedback.Application.Queries;
using ForumFeedback.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureDependency(builder.Configuration);
builder.Services.AddApplicationDependency();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Forum");
        c.RoutePrefix = string.Empty;
    });
}


app.MapPost("/Post", (CreatePostDto post, IPostCommand command) => command.CreatePost(post));
app.MapDelete("/Post", ([FromBody] DeleteDto post, IPostCommand command) => command.DeletePost(post));

app.MapPost("/Comment", (CreateCommentDto comment, ICommentCommand command) => command.CreateComment(comment));
app.MapPut("/Comment", (UpdateCommentDto comment, ICommentCommand command) => command.UpdateComment(comment));

app.MapPost("/Vote", (CreateVoteDto vote, IPostCommand command) => command.CreateVote(vote));
app.MapPut("/Vote", (UpdateVoteDto vote, IPostCommand command) => command.UpdateVote(vote));
app.MapDelete("/Vote", ([FromBody] DeleteVoteDto vote, IPostCommand command) => command.DeleteVote(vote));

app.MapGet("/Posts", (int activityId, IPostQuery query) => query.GetPosts(activityId));
app.MapGet("/Post", (int postId, IPostQuery query) => query.GetPostWithComments(postId));


app.Run();

