namespace ForumFeedback.Domain;

public class Post : DomainEntity
{
    public Guid ActivityGuid { get; protected set; }
    public Guid UserGuid { get; protected set; }
    public DateTime Time { get; protected set; }
    public string ProblemText { get; protected set; }
    public string Suggestion { get; protected set; }
    public List<Vote> Votes { get; protected set; }
    public List<Comment> Comments { get; protected set; }

    protected Post()
    {
        
    }

    private Post(Guid activityGuid, Guid userGuid, String problemText, string suggestion)
    {
        ActivityGuid = activityGuid;
        UserGuid = userGuid;
        ProblemText = problemText;
        Suggestion = suggestion;
        Time = DateTime.Now;
    }

    public static Post Create(Guid activityGuid, Guid userGuid, string problemText, string suggestion)
    {
        return new Post(activityGuid, userGuid, problemText, suggestion);
    }




}