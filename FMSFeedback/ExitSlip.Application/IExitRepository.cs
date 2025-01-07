using ExitSlip.Domain;

namespace ExitSlip.Application;

public interface IExitRepository
{
    Exit GetExit(int id);
    int AddExit(Exit exit);
}