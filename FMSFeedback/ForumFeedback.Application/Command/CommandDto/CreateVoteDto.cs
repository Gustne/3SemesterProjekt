namespace ForumFeedback.Application.Command.CommandDto;

public record CreateVoteDto
{
    public int PostId { get; set; }
    public bool IsVoteUp { get; set; }
    public Guid UserGuid { get; set; }
}