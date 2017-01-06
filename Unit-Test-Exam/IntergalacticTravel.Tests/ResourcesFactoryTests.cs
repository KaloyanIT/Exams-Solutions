namespace IntergalacticTravel.Tests
{
    using System;
    using IntergalacticTravel.Contracts;
    using Moq;
    using NUnit.Framework;
    using NUnit.Framework.Internal;

    [TestFixture, Explicit]
    public class ResourcesFactoryTests
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResources_IfParametersAreInValidFormat_ShouldNotThrowInvalidOperationException(string command)
        {
            var resourcesFactory = new ResourcesFactory();

            Assert.IsInstanceOf<IResources>(resourcesFactory.GetResources(command));
        }

        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void GetResources_IfParametersAreInInvalidFormat_ShouldThrowInvalidOperationException(string command)
        {
            var resourcesFactory = new ResourcesFactory();

            Assert.That(() => resourcesFactory.GetResources(command), Throws.InvalidOperationException.With.Message.Contains("Invalid command"));
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void GetResources_IfParemetersAreLargerThanUintMaxValue_ShouldThrowOverflowException(string command)
        {
            var resourcesFactory = new ResourcesFactory();

            Assert.Throws<OverflowException>(() => resourcesFactory.GetResources(command));
        }
    }
}