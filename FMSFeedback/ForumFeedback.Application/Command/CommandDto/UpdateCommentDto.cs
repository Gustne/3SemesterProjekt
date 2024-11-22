namespace ForumFeedback.Application.Command.CommandDto;

public record UpdateCommentDto
{
    public int CommentId { get; set; }
    public string Text { get; set; }
    public Guid UserGuid { get; set; }
}