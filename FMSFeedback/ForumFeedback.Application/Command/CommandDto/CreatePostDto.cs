namespace ForumFeedback.Application.Command.CommandDto;

public record CreatePostDto
{
    public Guid UserGuid { get; set; }
    public int ActivityId { get; set; }
    public string ProblemText { get; set; }
    public string Suggestion { get; set; }
}