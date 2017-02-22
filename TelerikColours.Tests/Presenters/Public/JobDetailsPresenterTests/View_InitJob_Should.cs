using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Moq;
using NUnit.Framework;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Mvp.Public.JobDetails;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Public.JobDetailsPresenterTests
{
    [TestFixture]
    public class View_InitJob_Should
    {
        [TestCase(22)]
        [TestCase(1)]

        public void SetJobOnViewModelWithExpectedObject_WhenIntFlightEventIsRaised(int jobId)
        {
            // Arrange
            var jobViewMock = new Mock<IJobDetailsView>();
            var jobServiceStub = new Mock<IJobService>();
            var userServiceStub = new Mock<IUserService>();
            var jobDetailPresenter = new JobDetailsPresenter(jobViewMock.Object,jobServiceStub.Object, userServiceStub.Object);

            jobViewMock.Setup(v => v.Model).Returns(new JobDetailsViewModel());

            var eventArgs = new JobDetailsCustomEventArgs(jobId);
            var expectedJob = new Job();

            jobServiceStub.Setup(j => j.GetJobById(jobId)).Returns(expectedJob);
            // Act
            jobViewMock.Raise(v => v.InitJob += null, eventArgs);

            // Assert
            Assert.AreEqual(expectedJob, jobViewMock.Object.Model.FoundJob);
        }
    }
}
