using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TelerikColours.Mvp.Admin.AddJob;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddJobPresenterTests
{
    [TestFixture]
    public class View_SubmitAddJob_Should
    {
        [Test]
        public void CallAddJobWithProvidedParametersOnce_WhenSubmitJobEventIsRaised()
        {
            // Arrange
            var stubbedView = new Mock<IAddJobView>();
            var stubbedFactoryService = new Mock<IFactoryService>();
            var stubbedLocationService = new Mock<ILocationService>();

            var addJobPresenter = new AddJobPresenter(stubbedView.Object, stubbedFactoryService.Object, stubbedLocationService.Object);
            var cityId = 1;
            var jobTitle = "Job Title 1";
            var jobDescription = "Job Description 1";
            var slots = 10;
            var startDate = new DateTime(2020, 10, 10);
            var endDate = new DateTime(2020, 11, 10);
            var wage = 10m;
            var companyName = "Company Name 1";
            var price = 10m;

            var addJobCustomEventArgs = new AddJobCustomEventArgs(cityId, jobTitle,
                jobDescription, slots, startDate,
                endDate, wage, companyName, price);


            // Act
            stubbedView.Raise(v => v.SubmitAddJob += null, addJobCustomEventArgs);

            // Assert
            stubbedFactoryService.Verify(f => f.AddJob(
                It.Is<string>(title => title == jobTitle),
                It.Is<string>(description => description == jobDescription),
                It.Is<int>(freeSlots => freeSlots == slots),
                It.Is<DateTime>(startingDate => startingDate == startDate),
                It.Is<DateTime>(endingDate => endingDate == endDate),
                It.Is<decimal>(dailyWage => dailyWage == wage),
                It.Is<string>(hiringCompanyName => hiringCompanyName == companyName),
                It.Is<decimal>(jobPrice => jobPrice == price),
                It.Is<int>(id => id == cityId)
                ), Times.Once);
        }

    }
}
