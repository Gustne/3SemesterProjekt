namespace ForumFeedback.Application.Queries.QueriesDto;

public record PostDto
{
    public int PostId { get; set; }
    public byte[] rowVersion { get; set; }
    public string ProblemText { get; set; }
    public string Suggestion { get; set; }
    public DateTime Time { get; set; }
    public IEnumerable<CommentDto> Comments { get; set; }
    public IEnumerable<VoteDto> Votes { get; set; }
}