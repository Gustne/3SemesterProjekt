using ExitSlip.Application.Queries.QueriesDto;

namespace ExitSlip.Application.Queries;

public interface IExitQuery
{
    IEnumerable<OverviewExitDto> GetExitOverview(int activityId);
    IEnumerable<DetailedExitDto> GetDetailedExit(int ExitId);
    IEnumerable<PersonalExitDto> GetPersonalExit(int ExitId, Guid userGuid);
}