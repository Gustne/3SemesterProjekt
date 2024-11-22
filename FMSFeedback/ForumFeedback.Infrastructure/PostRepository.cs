using ForumFeedback.Application;
using ForumFeedback.Domain;

namespace ForumFeedback.Infrastructure;

public class PostRepository : IPostRepository
{
    private readonly ForumFeedbackContext _db;

    public PostRepository(ForumFeedbackContext context)
    {
        _db = context;
    }

    void IPostRepository.AddPost(Post post)
    {
        _db.Posts.Add(post);
    }

    void IPostRepository.DeletePost(Post post, byte[] rowVersion)
    {
        _db.Entry(post).Property(nameof(post.RowVersion)).OriginalValue = rowVersion;
        _db.Posts.Remove(post);
    }

    Post IPostRepository.GetPost(int id)
    {
        return _db.Posts.Single(p => p.Id == id);
    }
}