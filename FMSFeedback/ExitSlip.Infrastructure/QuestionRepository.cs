using ExitSlip.Application;
using ExitSlip.Domain;

namespace ExitSlip.Infrastructure;

public class QuestionRepository : IQuestionRepository
{
    private readonly ExitSlipContext _db;
    public QuestionRepository(ExitSlipContext context)
    {
        _db = context;
    }
    Question IQuestionRepository.getQuestion(int id)
    {
        return _db.Questions.Single(q => q.Id == id);
    }
}