using Repositories.Contracts;
using System;
using TelerikColours.Data.Contracts;

namespace Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly IDbContext context;

        public EfUnitOfWork(IDbContext context)
        {
            if (context == null)
            {
                throw new NullReferenceException("DbContext");
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
