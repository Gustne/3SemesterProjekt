using ExitSlip.Application.Queries;
using ExitSlip.Application.Queries.QueriesDto;
using ExitSlip.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExitSlip.Infrastructure.Queries;

public class ExitQuery : IExitQuery
{
    private readonly ExitSlipContext _db;
    public ExitQuery(ExitSlipContext db)
    {
        _db = db;
    }

    IEnumerable<OverviewExitDto> IExitQuery.GetExitOverview(int activityId)
    {
        var result = _db.Exits
            .AsNoTracking()
            .Where(e => e.ActivityId == activityId)
            .Select(e => new OverviewExitDto
            {
                Name = e.Name,
                Date = e.Date,
                Visible = e.Visible,
                RowVersion = e.RowVersion
            });

        return result;
    }

    IEnumerable<DetailedExitDto> IExitQuery.GetDetailedExit(int ExitId)
    {
        var result = _db.Exits
            .AsNoTracking()
            .Where(e => e.Id == ExitId)
            .Include(e => e.Questions)
            .Select(e => new DetailedExitDto
            {
                ActivityId = e.ActivityId,
                Name = e.Name,
                Date = e.Date,
                Visible = e.Visible,
                Questions = e.Questions.Select(q => new QuestionDto
                {
                    QuestionId = q.Id,
                    QuestionText = q.QuestionText,
                    RowVersion = q.RowVersion,

                }).ToList()



            });

        return result;
    }



    IEnumerable<PersonalExitDto> IExitQuery.GetPersonalExit(int ExitId, Guid userGuid)
    {
        var result = _db.Exits
            .AsNoTracking()
            .Where(e => e.Id == ExitId && e.UserGuid == userGuid)
            .Include(e => e.Questions)
            .ThenInclude(q => q.Answers)
            .Select(e => new PersonalExitDto()
            {
                ActivityId = e.ActivityId,
                Name = e.Name,
                Date = e.Date,
                Visible = e.Visible,
                Questions = e.Questions.Select(q => new PersonalQuestionDto
                {
                    QuestionId = q.Id,
                    QuestionText = q.QuestionText,
                    AnswerText = q.Answers.FirstOrDefault().AnswerText

                }).ToList()

            });

        return result;
    }
}