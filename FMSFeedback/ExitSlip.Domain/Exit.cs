namespace ExitSlip.Domain;

public class Exit : DomainEntity
{
    public int ActivityId { get; protected set; }
    public string Name { get; protected set; }
    public DateOnly Date { get; protected set; }
    public Guid UserGuid { get; protected set; }
    public bool Visible { get; protected set; }
    public List<Question> Questions { get; protected set; }

    protected Exit()
    {

    }

    private Exit(int activityId, string name, DateOnly date, Guid userGuid, bool visible)
    {
        ActivityId = activityId;
        Name = name;
        Date = date;
        UserGuid = userGuid;
        Visible = visible;
    }

    public static Exit Create(int activityId, string name, DateOnly date, Guid userGuid, bool visible)
    {
        return new Exit(activityId, name, date, userGuid, visible);
    }

    public void CreateQuestion(string questionText)
    {
        var question = Question.Create(questionText);
        Questions.Add(question);
    }


}
