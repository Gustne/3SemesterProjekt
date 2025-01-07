namespace ExitSlip.Application.Queries.QueriesDto;

public record PersonalQuestionDto
{
    public int QuestionId { get; set; }
    public string QuestionText { get; set; }
    public string? AnswerText { get; set; }
}