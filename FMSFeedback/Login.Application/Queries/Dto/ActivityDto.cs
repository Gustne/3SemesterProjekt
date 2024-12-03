using Login.Domain.Entity;

namespace Login.Application.Queries.Dto;

public record ActivityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TermDto Term { get; set; }

}