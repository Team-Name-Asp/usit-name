using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.CustomEventArgs;
using TelerikColours.Mvp.Admin.AddCountry;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Admin.AddCountryPresenterTests
{
    [TestFixture]
    public class View_SubmitCountry_Should
    {
        [TestCase("Name1")]
        [TestCase("Traim")]
        public void CllAddCountryWithProvidedParametersOnce_WhenSubmitCountryEventIsRaised(string countryName)
        {
            // Arrange
            var stubbedView = new Mock<IAddCountryView>();
            var stubbedFactoryService = new Mock<IFactoryService>();
            var addCountryPresenter = new AddCountryPresenter(stubbedView.Object, stubbedFactoryService.Object);

            var addCountryCustomEventARgs = new AddCountryCustomEventArgs(countryName);

            // Act
            stubbedView.Raise(v => v.SubmitCountry += null, addCountryCustomEventARgs);

            // Assert
            stubbedFactoryService.Verify(f => f.AddCountry(It.Is<string>(name => name == countryName)), Times.Once);
        }
    }
}
