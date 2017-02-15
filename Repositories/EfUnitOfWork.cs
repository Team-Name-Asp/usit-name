using Repositories.Contracts;
using System;
using TelerikColours.Data.Contracts;

namespace Repositories
{
    public class EfUnitOfWork: IUnitOfWork
    {
        private readonly IDbContext context;

        public EfUnitOfWork(IDbContext context)
        {
            if (context == null)
            {
                throw new NullReferenceException();
            }

            this.context = context;
        }

        public void Commit()
        {
            try
            {
                this.context.SaveChanges();

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void Dispose()
        {
        }
    }
}
