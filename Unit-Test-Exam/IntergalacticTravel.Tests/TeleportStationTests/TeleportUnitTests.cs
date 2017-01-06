namespace IntergalacticTravel.Tests.TeleportStationTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using IntergalacticTravel.Contracts;
    using IntergalacticTravel.Tests.TeleportStationTests.Mock;
    using IntergalacticTravel.Exceptions;
    using Moq;
    using NUnit.Framework;
    using NUnit.Framework.Constraints;

    [TestFixture, Explicit]
    public class TeleportUnitTests
    {
        [Test]
        public void TeleportUnit_IfParameterUnitToTeleportIsNull_ShouldThrowArgumentNullException()
        {
            var buisnessOwner = new Mock<IBusinessOwner>();
            var location = new Mock<ILocation>();
            var galacticMap = new Mock<IEnumerable<IPath>>();
            IUnit unit = null;

            var testStation = new MockedTeleportStation(buisnessOwner.Object, galacticMap.Object, location.Object);

            Assert.That(() => testStation.TeleportUnit(unit, location.Object), Throws.ArgumentNullException.With.Message.Contains("unitToTeleport"));
        }

        [Test]
        public void TeleportUnit_CheckIfParameterLocationIsNull_ShouldThrowArgumentNullException()
        {
            var buisnessOwner = new Mock<IBusinessOwner>();
            var location = new Mock<ILocation>();
            var galacticMap = new Mock<IEnumerable<IPath>>();
            var unit = new Mock<IUnit>();
            ILocation locationToTeleport = null;

            var testStation = new MockedTeleportStation(buisnessOwner.Object, galacticMap.Object, location.Object);

            Assert.That(() => testStation.TeleportUnit(unit.Object, locationToTeleport), Throws.ArgumentNullException.With.Message.Contains("destination"));
        }

        [Test]
        public void TeleportUnit_IfLocationIsDistant_ShouldThrowTeleportOutOfRangeException()
        {
            var buisnessOwner = new Mock<IBusinessOwner>();
            var location = new Mock<ILocation>();
            var galacticMap = new List<IPath>();
            var locationToTeleport = new Mock<ILocation>();
            var galaxy = new Mock<IGalaxy>();
            var planet = new Mock<IPlanet>();
            var anotherPlanet = new Mock<IPlanet>();
            var path = new Mock<IPath>();
            var unit = new Mock<IUnit>();
            var path2 = new Mock<IPath>();
            var unit2 = new Mock<IUnit>();
            var resources = new Resources();
            unit.SetupGet(p => p.CurrentLocation).Returns(location.Object);
            unit2.SetupGet(p => p.CurrentLocation).Returns(locationToTeleport.Object);
            unit.SetupGet(p => p.Resources).Returns(resources);
            unit2.SetupGet(p => p.Resources).Returns(resources);
            galaxy.SetupGet(p => p.Name).Returns("FirstGalaxy");
            planet.SetupGet(p => p.Galaxy).Returns(galaxy.Object);
            planet.SetupGet(p => p.Name).Returns("Mars");
            location.SetupGet(p => p.Planet).Returns(planet.Object);
            anotherPlanet.SetupGet(p => p.Galaxy).Returns(galaxy.Object);
            anotherPlanet.SetupGet(p => p.Name).Returns("Neptun");
            galacticMap.Add(path.Object);
            planet.SetupGet(p => p.Units).Returns(() => new List<IUnit>() {unit.Object});
            galaxy.SetupGet(p => p.Planets).Returns(() => new List<IPlanet>() {planet.Object, anotherPlanet.Object});
            anotherPlanet.SetupGet(p => p.Units).Returns(() => new List<IUnit>() {unit2.Object});
            locationToTeleport.SetupGet(p => p.Planet).Returns(anotherPlanet.Object);
            path.SetupGet(p => p.TargetLocation).Returns(location.Object);
            path.SetupGet(p => p.TargetLocation.Planet.Units).Returns(() => new List<IUnit>() { unit.Object });
            path2.SetupGet(p => p.TargetLocation).Returns(locationToTeleport.Object);
            path2.SetupGet(p => p.TargetLocation.Planet.Units).Returns(() => new List<IUnit>() {unit.Object});
            path2.SetupGet(p => p.TargetLocation).Returns(locationToTeleport.Object);
            galacticMap.Add(path2.Object);



            var testStation = new MockedTeleportStation(buisnessOwner.Object, galacticMap, location.Object);

            //Assert.That(() => testStation.TeleportUnit(unit.Object, locationToTeleport.Object));
            //try
            //{
            //    testStation.TeleportUnit(unit.Object, locationToTeleport.Object);
            //}
            //catch (TeleportOutOfRangeException ex)
            //{
            //    Assert.AreEqual(ex.Message, "unitToTeleport.CurrentLocation");
            //}
            Assert.Throws<TeleportOutOfRangeException>(
                () => testStation.TeleportUnit(unit.Object, locationToTeleport.Object));
        }

        //[Test]
        //public void TeleportUnit_
    }
}