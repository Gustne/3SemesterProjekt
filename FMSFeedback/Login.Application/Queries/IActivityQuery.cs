using Login.Application.Queries.Dto;

namespace Login.Application.Queries;

public interface IActivityQuery
{
    IEnumerable<ActivityDto> GetForumActivities(Guid guid);
    IEnumerable<ActivityDto> GetExitActivities(Guid guid);
}