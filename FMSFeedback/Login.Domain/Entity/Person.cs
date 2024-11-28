using System.ComponentModel.DataAnnotations;

namespace Login.Domain.Entity;

public class Person
{
    [Timestamp]
    public byte[] RowVersion { get; protected set; }

    public Guid Id { get; protected set; }
    
    public string FirstName { get; protected set; }
    public string MiddleName { get; protected set; }
    public string LastName { get; protected set; }

    public string Email { get; protected set; }

    public bool IsStaff { get; protected set; }

    public List<Activity> Activities { get; protected set; }

}