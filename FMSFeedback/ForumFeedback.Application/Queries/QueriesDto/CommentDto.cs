using System.Runtime.InteropServices.JavaScript;

namespace ForumFeedback.Application.Queries.QueriesDto;

public record CommentDto
{
    public int PostId { get; set; }
    public Guid UserGuid { get; set; }
    public DateTime Time { get; set; }
    public IEnumerable<CommentTextDto> Text { get; set; }

}