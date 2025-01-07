using System.Runtime.InteropServices;

namespace ExitSlip.Application.Queries.QueriesDto;

public record OverviewExitDto
{
    public string Name { get; set; }
    public DateOnly Date { get; set; }
    public bool Visible { get; set; }
    public byte[] RowVersion { get; set; }

}