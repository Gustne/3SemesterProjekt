namespace ForumFeedback.Domain;

public class Vote : DomainEntity
{
    public Guid UserGuid { get; protected set; }
    public bool IsVoteUp { get; protected set; }

    // nav prop
    public Post Post { get; protected set; }

    protected Vote()
    {
        
    }

    private Vote(Guid userGuid, bool isVoteUp)
    {
        UserGuid = userGuid;
        IsVoteUp = isVoteUp;
    }


    public static Vote Create(Guid userGuid, bool isVoteUp)
    {
        return new Vote(userGuid, isVoteUp);
    }
}