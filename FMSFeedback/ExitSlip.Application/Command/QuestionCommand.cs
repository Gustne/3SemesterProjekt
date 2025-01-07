using ExitSlip.Application.Command.CommandDto;
using ExitSlip.Application.Command.Interfaces;
using ExitSlip.Application.Helpers;

namespace ExitSlip.Application.Command;

public class QuestionCommand : IQuestionCommand
{
    private readonly IQuestionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;


    public QuestionCommand(IQuestionRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    void IQuestionCommand.CreateAnswer(CreateAnswerDto answerDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var question = _repository.getQuestion(answerDto.QuestionId);
            question.CreateAnswer(answerDto.UserGuid, answerDto.AnswerText);

            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }

    }
}