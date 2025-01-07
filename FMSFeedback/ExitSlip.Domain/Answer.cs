namespace ExitSlip.Domain;

public class Answer : DomainEntity
{
     public Guid UserGuid { get; protected set; }

     public string AnswerText { get; protected set; }


     protected Answer()
     {
         
     }


     private Answer(Guid userGuid, string answerText)
     {
         UserGuid = userGuid;
         AnswerText = answerText;
     }

     internal static Answer Create(Guid userGuid, string answerText)
     {
         return new Answer(userGuid, answerText);
     }

     public void Update(string answerText)
     {
         AnswerText = answerText;
     }

}

