namespace ExitSlip.Application.Command.CommandDto;

public record CreateQuestionDto
{
    public int ExitID { get; set; }
    public List<string> Questions { get; set; }
}