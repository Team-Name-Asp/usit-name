//using Moq;
//using NUnit.Framework;
//using System;
//using TelerikColours.Mvp.Admin.EditFlight;
//using TelerikColours.Services.Contracts;

//namespace TelerikColours.Tests.Presenters.EditFlightPresenterTests
//{
//    [TestFixture]
//    public class ViewCommitChangesShould
//    {
//        [Test]
//        public void Call_SaveUpdateFlight_OnFlightService()
//        {
//            // Arrange
//            var viewStub = new Mock<IEditFlightView>();
//            var serviceMock = new Mock <IFlightService> ();
//            var editFlightPresenter = new EditFlightPresenter(viewStub.Object, serviceMock.Object);

//            // Act
//            editFlightPresenter.View_CommitChanges(It.IsAny<object>(), It.IsAny<EventArgs>());

//            // Assert
//            serviceMock.Verify(x => x.SaveUpdatedFlight(), Times.Once);
//        }
//    }
//}
