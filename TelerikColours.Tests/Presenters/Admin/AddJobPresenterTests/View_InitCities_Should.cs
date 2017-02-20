using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Moq;
using NUnit.Framework;
using TelerikColours.Mvp.Admin.AddJob;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddJobPresenterTests
{
    [TestFixture]
    public class View_InitCities_Should
    {
        [Test]
        public void SetCitiesOnViewModelWithExpectedCollection_WhenInitCitiesEventIsRaised()
        {
            // Arrange
            var stubbedView = new Mock<IAddJobView>();
            var stubbedFactoryService = new Mock<IFactoryService>();
            var stubbedLocationService = new Mock<ILocationService>();

            var addJobPresenter = new AddJobPresenter(stubbedView.Object, stubbedFactoryService.Object, stubbedLocationService.Object);

            var expectedCollection = new List<City>()
            {
                new City("City1", It.IsAny<int>()),
                new City("City2", It.IsAny<int>())
            };

            stubbedLocationService.Setup(l => l.GetAllCities()).Returns(expectedCollection);

            // Act
            stubbedView.Setup(v => v.Model).Returns(new AddJobViewModel());
            stubbedView.Raise(v => v.InitCities += null, new EventArgs());

            // Assert
            CollectionAssert.AreEqual(expectedCollection, addJobPresenter.View.Model.Cities);
        }
    }
}
