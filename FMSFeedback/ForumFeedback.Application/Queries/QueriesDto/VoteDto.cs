namespace ForumFeedback.Application.Queries.QueriesDto;

public record VoteDto
{
    public Guid UserGuid { get; set; }
    public bool IsVoteUp { get; set; }
    public byte[] RowVersion { get; set; }
}