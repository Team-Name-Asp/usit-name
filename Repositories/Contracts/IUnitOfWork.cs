using System;

namespace Repositories.Contracts
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
    }
}
