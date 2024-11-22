using System.Runtime.InteropServices.JavaScript;
using System.Xml.XPath;

namespace ForumFeedback.Domain;

public class Comment : DomainEntity
{
    public Guid UserGuid { get; protected set; }
    public DateTime Time { get; protected set; }

    public List<CommentText> CommentTexts { get; protected set; }

    // nav prop
    public Post Post { get; protected set; }

    protected Comment()
    {
        
    }

    private Comment(CommentText commentText, Guid userGuid)
    {
        CommentTexts.Add(commentText);
        UserGuid = userGuid;
        Time = DateTime.Now;
    }


    public static Comment Create(CommentText commentText, Guid userGuid)
    {
        return new Comment(commentText, userGuid);
    }
    



}