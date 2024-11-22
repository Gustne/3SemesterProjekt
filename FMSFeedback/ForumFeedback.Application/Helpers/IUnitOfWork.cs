using System.Data;

namespace ForumFeedback.Application.Helpers;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable);
}