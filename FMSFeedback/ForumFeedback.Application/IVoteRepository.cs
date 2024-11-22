using ForumFeedback.Domain;

namespace ForumFeedback.Application;

public interface IVoteRepository
{
    public Vote GetVote(int id);
    public void CreateVote(Vote vote);
    public void UpdateVote(Vote vote);
    public void DeleteVote(int id);
}