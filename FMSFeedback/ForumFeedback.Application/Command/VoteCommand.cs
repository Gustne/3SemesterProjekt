using ForumFeedback.Application.Command.CommandDto;
using ForumFeedback.Application.Command.Interfaces;
using ForumFeedback.Application.Helpers;

namespace ForumFeedback.Application.Command;

public class VoteCommand : IVoteCommand
{
    private readonly IVoteRepository _voteRepository;
    private readonly IPostRepository _postRepository;
    private readonly IUnitOfWork _unitOfWork;

    public VoteCommand(IVoteRepository voteRepository, IPostRepository postRepository, IUnitOfWork unitOfWork)
    {
        _voteRepository = voteRepository;
        _postRepository = postRepository;
        _unitOfWork = unitOfWork;
    }

    void IVoteCommand.CreateVote(CreateVoteDto voteDto)
    {
        
    }

    void IVoteCommand.DeleteVote(DeleteDto voteDto)
    {
        throw new NotImplementedException();
    }

    void IVoteCommand.UpdateVote(UpdateVoteDto voteDto)
    {
        throw new NotImplementedException();
    }
}