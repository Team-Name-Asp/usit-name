using Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Mvp.Public.Profile;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Public.ProfilePresenterTests
{
    [TestFixture]
    public class View_InitUpcommingJobs_Should
    {
        [TestCase("GuidGuidDudsa")]
        [TestCase("GuidGui21asddDudsa")]
        public void SetUpcommingJobsOnViewModelWithExpectedJobs_WhenInitUpcommingJobEventOtViewIsRaisedWithExpectedParam(string guid)
        {
            // Arrange
            var profileViewMock = new Mock<IProfileView>();
            var userServiceStub = new Mock<IUserService>();
            var presenter = new ProfilePresenter(profileViewMock.Object, userServiceStub.Object);

            var userCustomEventArgs = new UserCustomEventArgs(guid);
            profileViewMock.Setup(p => p.Model).Returns(new ProfileViewModel());

            var expectedJobs = new List<Job>()
            {
                new Job()
                {
                    Id = It.IsAny<int>()
                },
                   new Job()
                {
                    Id = It.IsAny<int>()
                }
            };

            userServiceStub.Setup(u => u.GetUpcommingJobs(guid)).Returns(expectedJobs);

            // Act
            profileViewMock.Raise(v => v.InitUpcommingJobs += null, userCustomEventArgs);

            // Assert
            CollectionAssert.AreEqual(expectedJobs, profileViewMock.Object.Model.UpcommingJobs);
        }
    }
}

