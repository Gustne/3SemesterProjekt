namespace ForumFeedback.Application.Command.CommandDto;

public record UpdateCommentDto : BaseDto
{
    public string Text { get; set; }
    public Guid UserGuid { get; set; }
}