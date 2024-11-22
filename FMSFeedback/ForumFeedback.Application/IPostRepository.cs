using ForumFeedback.Domain;

namespace ForumFeedback.Application;

public interface IPostRepository
{
    Post GetPost(int id);
    void AddPost(Post post);
    void DeletePost(Post post, byte[] rowVersion);
}