namespace ForumFeedback.Application.Queries.QueriesDto;

public record CommentTextDto
{
    public string Text { get; set; }
    public DateTime Time { get; set; }
}