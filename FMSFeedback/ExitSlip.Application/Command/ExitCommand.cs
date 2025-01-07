using ExitSlip.Application.Command.CommandDto;
using ExitSlip.Application.Command.Interfaces;
using ExitSlip.Application.Helpers;
using ExitSlip.Domain;

namespace ExitSlip.Application.Command;

public class ExitCommand : IExitCommand
{
    private readonly IExitRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ExitCommand(IExitRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    void IExitCommand.CreateExit(CreateExitDto exitDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var exit = Exit.Create(exitDto.ActivityId, exitDto.Name, exitDto.Date, exitDto.UserGuid, exitDto.Visible);

            _repository.AddExit(exit);
            
            _unitOfWork.Commit();
        }
        catch(Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }

    }

    void IExitCommand.CreateQuestion(CreateQuestionDto questionDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var exit = _repository.GetExit(questionDto.ExitID);

            if (exit == null)
            {
                throw new KeyNotFoundException($"there is not found any Exitslip with key{questionDto.ExitID}");
            }

            foreach (var questionText in questionDto.Questions)
            {
                exit.CreateQuestion(questionText);
            } 

            _unitOfWork.Commit();

        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }
}