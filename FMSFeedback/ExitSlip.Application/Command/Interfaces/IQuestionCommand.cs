using ExitSlip.Application.Command.CommandDto;

namespace ExitSlip.Application.Command.Interfaces;

public interface IQuestionCommand
{
    void CreateAnswer(CreateAnswerDto answerDto);
}