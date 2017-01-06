using System;
using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Pay_IfTheInputValueIsNull_ShouldThrowArgumentNullException()
        {
            var unitFactory = new UnitsFactory();
            var unit = unitFactory.GetUnit("create unit Procyon Gosho 1");
            IResources resources = null;

            Assert.Throws<NullReferenceException>(() => unit.Pay(resources));
        }
    }
}