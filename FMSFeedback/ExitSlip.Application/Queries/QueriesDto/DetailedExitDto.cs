namespace ExitSlip.Application.Queries.QueriesDto;

public record DetailedExitDto
{
    public int ActivityId { get; set; }
    public string Name { get; set; }
    public DateOnly Date { get; set; }
    public bool Visible { get; set; }
    public byte[] RowVersion { get; set; }
    public List<QuestionDto> Questions { get; set; }
}