using ExitSlip.Application;
using ExitSlip.Domain;

namespace ExitSlip.Infrastructure;

public class ExitRepository : IExitRepository
{
    private readonly ExitSlipContext _db;

    public ExitRepository(ExitSlipContext context)
    {
        _db = context;
    }

    Exit IExitRepository.GetExit(int id)
    {
        return _db.Exits.Single(e => e.Id == id);
    }

    int IExitRepository.AddExit(Exit exit)
    {
        _db.Exits.Add(exit);
        _db.SaveChanges();

        return exit.Id;
    }

}