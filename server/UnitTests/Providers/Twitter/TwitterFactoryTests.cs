using Core.Contracts;
using Moq;
using NUnit.Framework;
using Providers.Twitter;
using System;
using TweetSharp;

namespace UnitTests.Providers.Twitter
{
    public class TwitterFactoryTests
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void GivenNullTwitterService_ShouldThrowNullArgsException()
            {
                var service = new Mock<ITwitterService>();

                Assert.Throws<ArgumentNullException>(
                   () => new TwitterSharerFactory(service.Object, null));
            }

            [Test]
            public void GivenNullCredentialProvider_ShouldThrowNullArgsException()
            {
                var provider = new Mock<ICredentialProvider>();

                Assert.Throws<ArgumentNullException>(
                   () => new TwitterSharerFactory(null, provider.Object));
            }
        }

        [TestFixture]
        public class CreateSharer
        {
            [Test]
            public void ShouldCreateSharerInstance()
            {
                var service = new Mock<ITwitterService>();
                var provider = new Mock<ICredentialProvider>();
                var sut = new TwitterSharerFactory(service.Object, provider.Object);

                var instance = sut.CreateSharer();

                Assert.NotNull(instance);
            }
        }

        [TestFixture]
        public class AppliesTo
        {
            [Test]
            public void GivenIncorrectType_ShouldReturnFalse()
            {
                var service = new Mock<ITwitterService>();
                var provider = new Mock<ICredentialProvider>();
                var sut = new TwitterSharerFactory(service.Object, provider.Object);

                var result = sut.AppliesTo(typeof(Object));

                Assert.False(result);
            }

            [Test]
            public void GivenCorrectType_ShouldReturnTrue()
            {
                var service = new Mock<ITwitterService>();
                var provider = new Mock<ICredentialProvider>();
                var sut = new TwitterSharerFactory(service.Object, provider.Object);

                var result = sut.AppliesTo(typeof(TwitterSharer));

                Assert.True(result);
            }
        }
    }
}