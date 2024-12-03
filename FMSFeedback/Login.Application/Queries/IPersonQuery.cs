using Login.Application.Queries.Dto;

namespace Login.Application.Queries;

public interface IPersonQuery
{ 
    IEnumerable<PersonDto> GetPeople(int activityId);
}