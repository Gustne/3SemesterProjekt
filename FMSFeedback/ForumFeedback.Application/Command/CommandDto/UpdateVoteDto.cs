namespace ForumFeedback.Application.Command.CommandDto;

public record UpdateVoteDto : BaseDto
{
    public bool IsVoteUp { get; set; }
    public Guid UserGuid { get; set; }
}