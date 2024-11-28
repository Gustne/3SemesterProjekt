using ForumFeedback.Application.Command.CommandDto;
using ForumFeedback.Application.Command.Interfaces;
using ForumFeedback.Application.Helpers;
using ForumFeedback.Domain;

namespace ForumFeedback.Application.Command;

public class CommentCommand : ICommentCommand
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CommentCommand(ICommentRepository commentRepository, IPostRepository postRepository, IUnitOfWork unitOfWork)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
        _unitOfWork = unitOfWork;
    }

    void ICommentCommand.CreateComment(CreateCommentDto commentDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            var post = _postRepository.GetPost(commentDto.PostId);
            var commentText = CommentText.Create(commentDto.Comment);
            var comment = Comment.Create(commentText, commentDto.UserGuid, post);

            _commentRepository.CreateComment(comment);

            _unitOfWork.Commit();
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    void ICommentCommand.UpdateComment(UpdateCommentDto commentDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            var comment = _commentRepository.GetComment(commentDto.Id);
            var commentText = CommentText.Create(commentDto.Text);
            comment.UpdateComment(commentText, commentDto.UserGuid);

            _commentRepository.UpdateComment(comment, commentDto.RowVersion);

        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }
}