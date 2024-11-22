using ForumFeedback.Application.Command.CommandDto;

namespace ForumFeedback.Application.Command.Interfaces;

public interface ICommentCommand
{
    void AddComment(CreateCommentDto commentDto);
    void UpdateComment(UpdateCommentDto commentDto);
}