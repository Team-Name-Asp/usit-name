using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TelerikColours.Mvp.Public.SearchJob;

namespace TelerikColours.Tests.Presenters.Public.SearchJobPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowNullReference_WithMessageContaining_JobService_When_JobServiceIsNull()
        {
            // Arrange
            var viewStub = new Mock<ISearchJobView>();

            // Act & Assert
            Assert.That(
               () => new SearchJobPresenter(viewStub.Object, null),
               Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IJobService"));
        }
    }
}
