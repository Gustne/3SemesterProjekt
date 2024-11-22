using ForumFeedback.Application.Command.CommandDto;

namespace ForumFeedback.Application.Command.Interfaces;

public interface IVoteCommand
{
    void CreateVote(CreateVoteDto voteDto);
    void UpdateVote(UpdateVoteDto voteDto);
    void DeleteVote(DeleteDto voteDto);
}