using ForumFeedback.Application.Command.CommandDto;
using ForumFeedback.Application.Command.Interfaces;
using ForumFeedback.Application.Helpers;
using ForumFeedback.Domain;

namespace ForumFeedback.Application.Command;

public class PostCommand : IPostCommand
{
    private readonly IPostRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public PostCommand(IPostRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }



    void IPostCommand.CreatePost(CreatePostDto postDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var post = Post.Create(postDto.ActivityId, postDto.UserGuid, postDto.ProblemText, postDto.Suggestion);

            _repository.AddPost(post);

            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }   
    }



    void IPostCommand.DeletePost(DeleteDto deleteDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            var post = _repository.GetPost(deleteDto.Id);
            if (post == null)
            {
                throw new KeyNotFoundException("key not Found");
            }
            _repository.DeletePost(post, deleteDto.RowVersion);
            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    void IPostCommand.CreateVote(CreateVoteDto voteDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            var post = _repository.GetPost(voteDto.PostId);

            post.CreateVote(voteDto.UserGuid, voteDto.IsVoteUp);

            _unitOfWork.Commit();
        }
        catch (Exception e)
        {
            try
            {
                _unitOfWork.Rollback();
            }
            catch (Exception exception)
            {
                throw new Exception($"$rollback failed: {exception.Message}", e);
            }

            throw;
        }
    }


    void IPostCommand.UpdateVote(UpdateVoteDto voteDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            var post = _repository.GetPost(voteDto.PostId);

            var vote = post.UpdateVote(voteDto.UserGuid, voteDto.IsVoteUp);


            _unitOfWork.Commit();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    void IPostCommand.DeleteVote(DeleteDto voteDto)
    {
        throw new NotImplementedException();
    }




}