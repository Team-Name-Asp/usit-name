using NUnit.Framework;
using Repositories;
using System;
using Moq;
using System.Data.Entity;

namespace TelerikColours.Tests.Repositories.EfRepositoryTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Throw_NullReference_WithMessageContaining_DbContext()
        {


            //Assert.That(
              //() => new EfRepository<T>(null),
            //   Throws.InstanceOf<ArgumentOutOfRangeException>().With.Message.Contains("dsa"));
        }
    }
}

public class Dummy
{

}

//private readonly DbContext context;

//public EfRepository(DbContext context)
//{
//    if (context == null)
//    {
//        throw new NullReferenceException();
//    }

//    this.context = context;

//    this.DbSet = this.context.Set<T>();