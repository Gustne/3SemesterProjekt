using ForumFeedback.Application.Command;
using ForumFeedback.Application.Command.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ForumFeedback.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependency(this IServiceCollection services)
    {
        services.AddScoped<IPostCommand, PostCommand>();
        services.AddScoped<ICommentCommand, CommentCommand>();

        return services;
    }
}