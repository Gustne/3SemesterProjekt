namespace ExitSlip.Application.Command.CommandDto;

public record CreateExitDto
{
    public Guid UserGuid { get; set; }
    public int ActivityId { get; set; }
    public DateOnly Date { get; set; }
    public bool Visible { get; set; }
    public string Name { get; set; }

}