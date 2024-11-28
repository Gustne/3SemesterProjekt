using System.ComponentModel;
using System.Runtime.InteropServices.JavaScript;
using System.Xml.XPath;

namespace ForumFeedback.Domain;

public class Comment : DomainEntity
{
    public Guid UserGuid { get; protected set; }
    public DateTime Time { get; protected set; }

    public List<CommentText> CommentTexts { get; protected set; } = new List<CommentText>();

    // nav prop
    public Post Post { get; protected set; }

    protected Comment()
    {
        
    }

    private Comment(CommentText commentText, Guid userGuid, Post post)
    {
        CommentTexts.Add(commentText);
        UserGuid = userGuid;
        Time = DateTime.Now;
        Post = post;
    }


    public static Comment Create(CommentText commentText, Guid userGuid, Post post)
    {
        return new Comment(commentText, userGuid, post);
    }

    public void UpdateComment(CommentText commentText, Guid userGuid)
    {
        //Todo logic to control for UserGuid
        
        CommentTexts.Add(commentText);
    }


}