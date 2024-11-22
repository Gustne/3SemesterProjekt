namespace ForumFeedback.Application.Command.CommandDto;

public record CreateCommentDto
{
    public Guid UserGuid { get; set; }
    public int PostId { get; set; }
    public string Comment { get; set; }
}