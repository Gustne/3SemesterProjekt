using ForumFeedback.Domain;

namespace ForumFeedback.Application;

public interface IPostRepository
{
    Post GetPost(int id);
    Post GetPostWithVotes(int id);
    void AddPost(Post post);
    void DeletePost(Post post, byte[] rowVersion);
    void DeleteVote(Vote vote, byte[] rowVersion);
}