using ForumFeedback.Application.Command.CommandDto;

namespace ForumFeedback.Application.Command.Interfaces;

public interface ICommentCommand
{
    void CreateComment(CreateCommentDto commentDto);
    void UpdateComment(UpdateCommentDto commentDto);
}