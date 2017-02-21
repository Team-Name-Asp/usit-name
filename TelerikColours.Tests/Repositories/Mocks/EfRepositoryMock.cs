using Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Data.Contracts;

namespace TelerikColours.Tests.Repositories.Mocks
{
    public class EfRepositoryMock<T> : EfRepository<T> where T : class
    {
        public EfRepositoryMock(IDbContext context) : base(context)
        {

        }

        public DbSet<T> MyDbSet
        {
            get
            {
                return base.DbSet;
            }
        }
    }
}
