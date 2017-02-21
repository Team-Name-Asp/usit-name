using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Mvp.Public.Profile;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Public.ProfilePresenterTests
{
    [TestFixture]
    class View_InitJobsHistory_Should
    {
        [TestCase("GuidGuidDudsa")]
        [TestCase("GuidGui21asddDudsa")]
        public void SetJobHistoryOnViewModelWithExpectedJobs_whenInitJobHistoryEventOtViewIsRaisedWithExpectedParam(string guid)
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

            userServiceStub.Setup(u => u.GetJobsHistory(guid)).Returns(expectedJobs);

            // Act
            profileViewMock.Raise(v => v.InitJobsHistory += null, userCustomEventArgs);

            // Assert
            CollectionAssert.AreEqual(expectedJobs, profileViewMock.Object.Model.JobsHistory);
        }
    }
}

