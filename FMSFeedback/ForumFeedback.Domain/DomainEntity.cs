using System.ComponentModel.DataAnnotations;

namespace ForumFeedback.Domain;

public abstract class DomainEntity
{
    public int Id { get; protected set; }
    
    public byte[] RowVersion { get; protected set; }
}
