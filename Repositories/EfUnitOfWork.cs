using Repositories.Contracts;
using System;
using System.Data.Entity;

namespace Repositories
{
    public class EfUnitOfWork: IUnitOfWork
    {
        private readonly DbContext context;

        public EfUnitOfWork(DbContext context)
        {
            if (context == null)
            {
                throw new NullReferenceException();
            }

            this.context = context;
        }

        public void Commit()
        {
                this.context.SaveChanges();        
        }

        public void Dispose()
        {
        }
    }
}
