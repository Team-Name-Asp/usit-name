using Moq;
using NUnit.Framework;
using System;
using TelerikColours.Mvp.Public.Profile;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Public.ProfilePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowNullReferenceWithMessageContainingIUserService_WhenUserServiceIsNull()
        {
            // Arrange
            var profileViewStub = new Mock<IProfileView>();

            // Act and Assert
            Assert.That(() => new ProfilePresenter(profileViewStub.Object, null), Throws.InstanceOf<NullReferenceException>().With.Message.Contains("IUserService"));
        }

        [Test]
        public void NotThrow_WhenEverythingIsPassed()
        {
            // Arrange
            var profileViewStub = new Mock<IProfileView>();
            var userServiceStub = new Mock<IUserService>();

            // Act and Assert
            Assert.DoesNotThrow(() => new ProfilePresenter(profileViewStub.Object, userServiceStub.Object));
        }
    }
}
