namespace ExitSlip.Application.Queries.QueriesDto;

public record ReviewAnswerDto
{
    public Guid userGuid { get; set; }
    public string AnswerText { get; set; }
}