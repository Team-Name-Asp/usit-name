using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikColours.Services;

namespace TelerikColours.Tests.Services.AirlineServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowNullReferenceException_WithMessageContaining_AirlineRepository_WhenIsNull()
        {
            // Act and Assert and Assert
            Assert.That(
               () => new AirlineService(null),
               Throws.InstanceOf<NullReferenceException>().With.Message.Contains("AirlineRepository"));
        }
    }
}
