using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TelerikColours.Mvp.Public.JobDetails;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Public.JobDetailsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowNullReferenceExceptionWithMessageContainingIJobService_WhenIJobServiceIsNull()
        {
            // Arrange
            var jobDetailsViewStub = new Mock<IJobDetailsView>();
            var userServiceStub = new Mock<IUserService>();

            // Act and Assert
            Assert.That(() =>
            new JobDetailsPresenter(jobDetailsViewStub.Object, null, userServiceStub.Object), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IJobService"));
        }

        [Test]
        public void ThrowNullReferenceExceptionWithMessageContainingIUserService_WhenIUserServiceIsNull()
        {
            // Arrange
            var jobDetailsViewStub = new Mock<IJobDetailsView>();
            var jobServiceStub = new Mock<IJobService>();

            // Act and Assert
            Assert.That(() =>
            new JobDetailsPresenter(jobDetailsViewStub.Object, jobServiceStub.Object, null), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IUserService"));
        }

        [Test]
        public void NotThrow_WhenEverythingIsSet()
        {
            // Arrange
            var jobDetailsViewStub = new Mock<IJobDetailsView>();
            var jobServiceStub = new Mock<IJobService>();
            var userServiceStub = new Mock<IUserService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new JobDetailsPresenter(jobDetailsViewStub.Object, jobServiceStub.Object, userServiceStub.Object));
        }
    }
}
