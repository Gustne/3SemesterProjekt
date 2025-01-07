using System.Data;

namespace ExitSlip.Application.Helpers;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable);
}