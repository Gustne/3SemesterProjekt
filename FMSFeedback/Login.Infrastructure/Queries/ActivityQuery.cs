using Login.Application.Queries;
using Login.Application.Queries.Dto;
using Microsoft.EntityFrameworkCore;

namespace Login.Infrastructure.Queries;

public class ActivityQuery : IActivityQuery
{
    private readonly LoginContext _db;
    public ActivityQuery(LoginContext db)
    {
        _db = db;
    }
    IEnumerable<ActivityDto> IActivityQuery.GetExitActivities(Guid guid)
    {
        var result = _db.People
            .AsNoTracking()
            .Where(p => p.Id == guid)
            .Include(p => p.Activities)
                .ThenInclude(a => a.Term)
            .Select(p => p.Activities
                .Where(a => a.ExitSlipEnabled == true)
                .Select(a => new ActivityDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Term = new TermDto
                    {
                        Year = a.Term.Year,
                        YearHalf = a.Term.YearHalf
                    }
                }).ToList())
            .SingleOrDefault();

        return result;

    }

    IEnumerable<ActivityDto> IActivityQuery.GetForumActivities(Guid guid)
    {
        var result = _db.People
            .AsNoTracking()
            .Where(p => p.Id == guid)
            .Include(p => p.Activities)
            .ThenInclude(a => a.Term)
            .Select(p => p.Activities
                .Where(a => a.FeedBackEnabled == true)
                .Select(a => new ActivityDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Term = new TermDto
                    {
                        Year = a.Term.Year,
                        YearHalf = a.Term.YearHalf
                    }
                }).ToList())
            .SingleOrDefault();

        return result;
    }
}