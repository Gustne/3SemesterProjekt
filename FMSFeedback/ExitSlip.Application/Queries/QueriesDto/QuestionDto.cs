namespace ExitSlip.Application.Queries.QueriesDto;

public record QuestionDto
{
    public int QuestionId { get; set; }
    public string QuestionText { get; set; }
    public byte[] RowVersion { get; set; }
}