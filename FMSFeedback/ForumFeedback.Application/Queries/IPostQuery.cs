using ForumFeedback.Application.Queries.QueriesDto;

namespace ForumFeedback.Application.Queries;

public interface IPostQuery
{
    IEnumerable<PostDto> GetPosts(Guid activityGuid);
    IEnumerable<PostDto> GetPostWithComments(int PostId);
}