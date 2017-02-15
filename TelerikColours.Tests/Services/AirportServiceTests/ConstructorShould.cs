using NUnit.Framework;
using System;
using TelerikColours.Services;

namespace TelerikColours.Tests.Services.AirportServiceTests
{
    [TestFixture]
    class ConstructorShould
    {
        [Test]
        public void ShoudThrow_NullReference_WithMessage_AirportRepository_WhenAirportRepository_IsNull()
        {
            Assert.That(
           () => new AirportService(null),
           Throws.InstanceOf<NullReferenceException>().With.Message.Contains("AirportRepository"));
        }
    }
}
