using ForumFeedback.Application.Command.CommandDto;
using ForumFeedback.Application.Queries.QueriesDto;

namespace ForumFeedback.Application.Command.Interfaces;

public interface IPostCommand
{
    void CreatePost(CreatePostDto postDto);
    void DeletePost(DeleteDto deleteDto);
    void CreateVote(CreateVoteDto voteDto);
    void UpdateVote(UpdateVoteDto voteDto);
    void DeleteVote(DeleteDto  voteDto);
}