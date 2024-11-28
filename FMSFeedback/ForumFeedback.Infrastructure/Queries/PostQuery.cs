using ForumFeedback.Application.Queries;
using ForumFeedback.Application.Queries.QueriesDto;
using Microsoft.EntityFrameworkCore;

namespace ForumFeedback.Infrastructure.Queries;

public class PostQuery : IPostQuery
{
    private readonly ForumFeedbackContext _db;
    public PostQuery(ForumFeedbackContext db)
    {
        _db = db;
    }

    IEnumerable<PostDto> IPostQuery.GetPosts(int activityId)
    {
        var result = _db.Posts
            .AsNoTracking()
            .Where(p => p.ActivityId == activityId)
            .Include(p => p.Votes)
            .Select(p => new PostDto
            {
                PostId = p.Id,
                ProblemText = p.ProblemText,
                Suggestion = p.Suggestion,
                rowVersion = p.RowVersion,
                Time = p.Time,
                Votes = p.Votes.Select(v => new VoteDto()
                {
                    UserGuid = v.UserGuid,
                    IsVoteUp = v.IsVoteUp,
                    RowVersion = v.RowVersion

                }).ToList()

            });

        return result;
    }

    IEnumerable<PostDto> IPostQuery.GetPostWithComments(int postId)
    {
        var result = _db.Posts
            .AsNoTracking()
            .Where(p => p.Id == postId)
            .Include(p => p.Votes)
            .Include(p => p.Comments)
            .ThenInclude(c => c.CommentTexts)
            .Select(p => new PostDto
            {
                PostId = p.Id,
                ProblemText = p.ProblemText,
                Suggestion = p.Suggestion,
                rowVersion = p.RowVersion,
                Time = p.Time,
                Votes = p.Votes.Select(v => new VoteDto
                {
                    UserGuid = v.UserGuid,
                    IsVoteUp = v.IsVoteUp,
                    RowVersion = v.RowVersion,

                }).ToList(),
                   

                Comments = p.Comments.Select(c => new CommentDto
                {
                    UserGuid = c.UserGuid,
                    Time = c.Time,
                    rowVersion = c.RowVersion,
                    Text = c.CommentTexts.Select(t => new CommentTextDto
                    {
                        Text = t.Text,
                        Time = t.Time,
                    }).ToList(),
                }).ToList(),

            });

        return result;
    }
}