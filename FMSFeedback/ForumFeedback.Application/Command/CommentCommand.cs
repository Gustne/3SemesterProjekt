using ForumFeedback.Application.Command.CommandDto;
using ForumFeedback.Application.Command.Interfaces;

namespace ForumFeedback.Application.Command;

public class CommentCommand : ICommentCommand
{
    void ICommentCommand.AddComment(CreateCommentDto commentDto)
    {
        throw new NotImplementedException();
    }

    void ICommentCommand.UpdateComment(UpdateCommentDto commentDto)
    {
        throw new NotImplementedException();
    }
}