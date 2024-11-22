using ForumFeedback.Application.Queries.QueriesDto;

namespace ForumFeedback.Application.Queries;

public interface IPostQuery
{
    IEnumerable<PostDto> GetPosts(int activityId);
    IEnumerable<PostDto> GetPostWithComments(int PostId);
}