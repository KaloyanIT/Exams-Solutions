using System.Collections.Generic;
namespace IntergalacticTravel.Tests.TeleportStationTests
{
    using IntergalacticTravel.Contracts;
    using IntergalacticTravel.Tests.TeleportStationTests.Mock;
    using Moq;
    using NUnit.Framework;

    [TestFixture, Explicit]
    public class ConstructorTests
    {
        [Test]
        public void TeleportStationConstructor_IfTeleportStationIsSetUpWithValidParams_ShouldConstructorSetUpAllProvidedFields()
        {
            var buisnessOwner = new Mock<IBusinessOwner>();
            var location = new Mock<ILocation>();
            var galacticMap = new Mock<IEnumerable<IPath>>();

            var testStation = new MockedTeleportStation(buisnessOwner.Object, galacticMap.Object, location.Object);

            Assert.IsInstanceOf<ITeleportStation>(testStation);
        }
    }
}