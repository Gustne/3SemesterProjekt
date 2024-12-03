namespace Login.Application.Queries.Dto;

public record PersonDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}