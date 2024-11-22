namespace ForumFeedback.Application.Command.CommandDto;

public record UpdateVoteDto : BaseDto
{
    public int PostId { get; set; }
    public bool IsVoteUp { get; set; }
    public Guid UserGuid { get; set; }
}