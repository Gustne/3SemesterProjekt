namespace ExitSlip.Domain;

public class Question : DomainEntity
{
    public string QuestionText { get; protected set; }
    public Exit ExitSlip { get; protected set; }

    public List<Answer> Answers { get; protected set; } = new List<Answer>();


    protected Question()
    {
        
    }

    private Question(string questionText)
    {
        QuestionText = questionText;
    }

    internal static Question Create(string questionText)
    {
        return new Question(questionText);
    }

    public void CreateAnswer(Guid userGuid, string answerText)
    {
        var answer = Answer.Create(userGuid, answerText);
        Answers.Add(answer);
    }
}