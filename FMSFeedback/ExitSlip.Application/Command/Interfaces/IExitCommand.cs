using ExitSlip.Application.Command.CommandDto;

namespace ExitSlip.Application.Command.Interfaces;

public interface IExitCommand
{
    void CreateExit(CreateExitDto exitDto);
    void CreateQuestion(CreateQuestionDto  questionDto);
}