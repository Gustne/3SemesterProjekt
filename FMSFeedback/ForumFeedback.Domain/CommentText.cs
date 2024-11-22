using System.Xml.XPath;

namespace ForumFeedback.Domain;

public class CommentText : DomainEntity
{
    public string Text { get; protected set; }
    public DateTime Time { get; protected set; }

    //nav prop
    public Comment Comment { get; protected set; }

    protected CommentText()
    {
        
    }

    private CommentText(string text)
    {
        Text = text;
        Time = DateTime.Now;
    }

    public static CommentText Create(string text)
    {
        return new CommentText(text);
    }

}