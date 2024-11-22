using ForumFeedback.Domain;

namespace ForumFeedback.Application;

public interface ICommentRepository
{
    public Comment GetComment(int it);
    public void CreateComment(Comment comment);
}