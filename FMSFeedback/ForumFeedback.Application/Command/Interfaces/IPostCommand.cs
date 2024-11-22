using ForumFeedback.Application.Command.CommandDto;

namespace ForumFeedback.Application.Command.Interfaces;

public interface IPostCommand
{
    void CreatePost(CreatePostDto postDto);
    void DeletePost(DeleteDto deleteDto);
}