namespace Login.Domain.Entity;

public class Activity : DomainEntity
{
    public string Name { get;protected set; }
    public Term Term { get;protected set; }
    public Location Location { get; protected set; }
    public List<Person> Persons { get; protected set; }
    public bool ExitSlipEnabled { get; protected set; }
    public bool FeedBackEnabled { get;protected set; }
}
