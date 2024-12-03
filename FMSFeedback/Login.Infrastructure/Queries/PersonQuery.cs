using Login.Application.Queries;
using Login.Application.Queries.Dto;
using Microsoft.EntityFrameworkCore;

namespace Login.Infrastructure.Queries;

public class PersonQuery : IPersonQuery
{
    private readonly LoginContext _db;
    public PersonQuery(LoginContext db)
    {
        _db = db;
    }

    IEnumerable<PersonDto> IPersonQuery.GetPeople(int activityId)
    {
        var result = _db.People
            .AsNoTracking()
            .Where(p => !p.IsStaff && p.Activities.Any(a => a.Id == activityId))
            .Select(p => new PersonDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
            }).ToList();
        return result;
    }
}