using ForumFeedback.Application;
using ForumFeedback.Domain;
using Microsoft.EntityFrameworkCore;

namespace ForumFeedback.Infrastructure;

public class CommentRepository : ICommentRepository
{
    private readonly ForumFeedbackContext _db;

    public CommentRepository(ForumFeedbackContext db)
    {
        _db = db;
    }

    Comment ICommentRepository.GetComment(int id)
    {
        return _db.Comments.Include(c => c.CommentTexts)
            .Single(c => c.Id == id);
    }

    void ICommentRepository.CreateComment(Comment comment)
    {
        _db.Comments.Add(comment);
    }

    void ICommentRepository.UpdateComment(Comment comment, byte[] rowVersion)
    {
        _db.Entry(comment).Property(nameof(comment.RowVersion)).OriginalValue = rowVersion;
    }
}