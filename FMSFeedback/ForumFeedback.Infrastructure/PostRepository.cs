using ForumFeedback.Application;
using ForumFeedback.Domain;
using Microsoft.EntityFrameworkCore;

namespace ForumFeedback.Infrastructure;

public class PostRepository : IPostRepository
{
    private readonly ForumFeedbackContext _db;

    public PostRepository(ForumFeedbackContext context)
    {
        _db = context;
    }

    Post IPostRepository.GetPost(int id)
    {
        return _db.Posts.Single(p => p.Id == id);
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


    void IPostRepository.DeleteVote(Vote vote, byte[] rowVersion)
    {
        _db.Entry(vote).Property(nameof(vote.RowVersion)).OriginalValue = rowVersion;
        _db.Votes.Remove(vote);
    }

    Post IPostRepository.GetPostWithVotes(int id)
    {
        return _db.Posts.Include(p => p.Votes).Single(p => p.Id == id);
    }
}