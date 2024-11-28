namespace ForumFeedback.Application.Command.CommandDto;

public record DeleteVoteDto : BaseDto
{
    public Guid UserGuid { get; set; }
    public int PostId { get; set; }
}