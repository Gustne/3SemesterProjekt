using ForumFeedback.Domain;
using Microsoft.EntityFrameworkCore;

namespace ForumFeedback.Infrastructure;

public class ForumFeedbackContext : DbContext
{
    public ForumFeedbackContext(DbContextOptions<ForumFeedbackContext> options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Vote> Votes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentText> CommentTexts {get; set; }

}