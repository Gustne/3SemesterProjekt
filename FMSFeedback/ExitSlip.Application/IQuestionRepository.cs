using ExitSlip.Domain;

namespace ExitSlip.Application;

public interface IQuestionRepository
{
    Question getQuestion(int id);
}