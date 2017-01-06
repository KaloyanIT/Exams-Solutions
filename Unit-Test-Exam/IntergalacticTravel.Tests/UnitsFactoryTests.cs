namespace IntergalacticTravel.Tests
{
    using IntergalacticTravel.Contracts;
    using IntergalacticTravel.Exceptions;
    using NUnit.Framework;

    [TestFixture, Explicit]
    public class UnitsFactoryTests
    {
        [TestCase("create unit Procyon Gosho 1")]
        [TestCase("create unit Luyten Pesho 2")]
        [TestCase("create unit Lacaille Tosho 3")]
        public void GetUnit_CheckIfCreateNewObject_ShoudNotThrowInvalidUnitCreationCommandException(string command)
        {
            var unitFactory = new UnitsFactory();

            Assert.IsInstanceOf<IUnit>(unitFactory.GetUnit(command));
        }
        [TestCase(null)]
        [TestCase("create Lacaille Tosho 3")]
        [TestCase("create unit Car Tosho 3")]
        public void GetUnit_IfCommandIsInvalid_ShouldThrowInvalidUnitCreationCommandException(string command)
        {
            var unitFactory = new UnitsFactory();
            Assert.Throws<InvalidUnitCreationCommandException>(() => unitFactory.GetUnit(command));
        }
    }
}