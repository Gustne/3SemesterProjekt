using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace ForumFeedback.Domain;

public class Post : DomainEntity
{
    public int ActivityId { get; protected set; }
    public Guid UserGuid { get; protected set; }
    public DateTime Time { get; protected set; }
    public string ProblemText { get; protected set; }
    public string Suggestion { get; protected set; }
    public List<Vote> Votes { get; protected set; }
    public List<Comment> Comments { get; protected set; }

    protected Post()
    {
        
    }

    private Post(int activityId, Guid userGuid, String problemText, string suggestion)
    {
        ActivityId = activityId;
        UserGuid = userGuid;
        ProblemText = problemText;
        Suggestion = suggestion;
        Time = DateTime.Now;
    }

    public static Post Create(int activityId, Guid userGuid, string problemText, string suggestion)
    {
        return new Post(activityId, userGuid, problemText, suggestion);
    }

    public void CreateVote(Guid userGuid, bool isVoteUp)
    {
        var vote = Vote.Create(userGuid, isVoteUp);
        Votes.Add(vote);
    }

    public Vote UpdateVote(Guid userGuid, bool isVoteUp)
    {
        var vote = Votes.FirstOrDefault(v => v.UserGuid == userGuid);
        if (vote == null) throw new ArgumentException("vote not found");
        vote.Update(isVoteUp);
        return vote;
    }

    public Vote DeleteVote(Guid userGuid)
    {
        var vote = Votes.FirstOrDefault(v => v.UserGuid == userGuid);
        if (vote == null) throw new ArgumentException("vote not found");
        return vote;
    }


}