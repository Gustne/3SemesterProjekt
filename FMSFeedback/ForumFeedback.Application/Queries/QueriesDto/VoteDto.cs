namespace ForumFeedback.Application.Queries.QueriesDto;

public record VoteDto
{
    public Guid UserGuid { get; set; }
    public bool isVoteUp { get; set; }
}