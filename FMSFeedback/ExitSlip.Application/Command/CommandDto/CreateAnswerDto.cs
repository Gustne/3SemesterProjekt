namespace ExitSlip.Application.Command.CommandDto;

public record CreateAnswerDto
{
    public int QuestionId { get; set; }
    public Guid UserGuid { get; set; }
    public string AnswerText { get; set; }

}