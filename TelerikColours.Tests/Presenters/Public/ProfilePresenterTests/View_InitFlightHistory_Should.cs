﻿using Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TelerikColours.Mvp.CustomEventArgs;
using TelerikColours.Mvp.Public.Profile;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Tests.Presenters.Public.ProfilePresenterTests
{
    [TestFixture]
    public class View_InitFlightHistory_Should
    {
        [TestCase("GuidGuidDudsa")]
        [TestCase("GuidGui21asddDudsa")]
        public void SetFlightHistoryOnViewModelWithExpectedCollection_WhenInitFlightHistoryEventIsRaised(string guid)
        {
            // Arrange
            var profileViewStub = new Mock<IProfileView>();
            var userServiceStub = new Mock<IUserService>();
            var presenter = new ProfilePresenter(profileViewStub.Object, userServiceStub.Object);

            var userCustomEventArgs = new UserCustomEventArgs(guid);
            profileViewStub.Setup(p => p.Model).Returns(new ProfileViewModel());

            var expectedFlights = new List<Flight>()
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

            userServiceStub.Setup(u => u.GetFlightHistory(guid)).Returns(expectedFlights);

            // Act
            profileViewStub.Raise(p => p.InitFlightHistory += null, userCustomEventArgs);

            // Assert
            CollectionAssert.AreEqual(expectedFlights, profileViewStub.Object.Model.FlightHistory);
        }
    }
}
