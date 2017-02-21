using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Moq;
using NUnit.Framework;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Mvp.Public.SearchJob;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Public.SearchJobPresenterTests
{
    [TestFixture]
    public class View_InitSubmit_Should
    {
        [Test]
        public void Set_Jobs_OnViewModel_WithExpectedCollection()
        {
            // Arrange
            var viewMock = new Mock<ISearchJobView>();
            viewMock.Setup(v => v.Model).Returns(new SearchJobViewModel());

            var jobServiceMock = new Mock<IJobService>();

            var presenter = new SearchJobPresenter(viewMock.Object, jobServiceMock.Object);

            var expectedCollection = new List<Job>()
            {
                new Job(1, "Job Title 1", "Job Description 1", 1, new DateTime(2020, 10, 10), new DateTime(2020, 11, 10), 10m, "Company Name 1" , 10.00m, "/imagePath"),
                new Job(1, "Job Title 2", "Job Description 2", 2, new DateTime(2020, 12, 10), new DateTime(2021, 01, 10), 10m, "Company Name 2" , 20.00m, "/imagePath"),
            };

            jobServiceMock.Setup(j => j.GetAllJobsFromByTerm("job")).Returns(expectedCollection.AsQueryable);
            var customEventArgs = new SearchJobCustomEventArgs("job");

            // Act
            presenter.View_InitSubmit(null, customEventArgs);

            // Assert
            CollectionAssert.AreEqual(expectedCollection.AsQueryable(), presenter.View.Model.FoundJobs);
        }
    }
}
