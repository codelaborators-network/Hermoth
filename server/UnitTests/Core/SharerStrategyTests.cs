using Core;
using Core.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace UnitTests.Core
{
    public class SharerStrategyTests
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void GivenNullCollection_ShouldThrowArgNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new SharerStrategy(null));
            }

            [Test]
            public void GivenValidCollection_ShouldCreateInstance()
            {
                var factory = new Mock<ISharableFactory>();

                Assert.DoesNotThrow(
                    () => new SharerStrategy(new[] { factory.Object }));
            }
        }

        [TestFixture]
        public class Create
        {
            [Test]
            public void GivenValidType_ShouldCreateInstanceOfType()
            {
                var factory = new Mock<ISharableFactory>();
                factory.Setup(f => f.AppliesTo(typeof(Object))).Returns(true);
                var sut = new SharerStrategy(new[] { factory.Object });

                var result = sut.Create(typeof(Object));

                factory.Verify(f => f.AppliesTo(typeof(Object)), Times.Once);
                factory.Verify(f => f.CreateSharer(), Times.Once);
            }

            [Test]
            public void GivenInvalidType_ShouldThrowException()
            {
                var factory = new Mock<ISharableFactory>();
                factory.Setup(f => f.AppliesTo(typeof(Object))).Returns(true);
                var sut = new SharerStrategy(new[] { factory.Object });

                Assert.Throws<Exception>(
                    () => sut.Create(typeof(string)));
            }
        }
    }
}