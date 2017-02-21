using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Mvp.Public.Home;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Public.HomePresenterTests
{
    [TestFixture]
    public class View_InitialLoad_Should
    {
        [Test]
        public void SetCheapestFlightsOnViewModel_WhenInitialLoadEventIsRaised()
        {
            // Arrange
            var homeViewMock = new Mock<IHomeView>();
            var flightServiceStub = new Mock<IFlightService>();
            var jobServiceStub = new Mock<IJobService>();

            var presenter = new HomePresenter(homeViewMock.Object, flightServiceStub.Object, jobServiceStub.Object);

            homeViewMock.Setup(v => v.Model).Returns(new HomeViewModel());

            var expectedCollection = new List<Flight>()
            {
                new Flight()
                {
                    Id = It.IsAny<int>()
                },
                new Flight()
                {
                    Id = It.IsAny<int>()
                }
            };

            flightServiceStub.Setup(f => f.GetCheapestFlights()).Returns(expectedCollection);

            // Act
            homeViewMock.Raise(v => v.InitialLoad += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEqual(expectedCollection, homeViewMock.Object.Model.CheapestFlights);
        }
    }
}
