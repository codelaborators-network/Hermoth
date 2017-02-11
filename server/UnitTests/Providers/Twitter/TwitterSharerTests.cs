using Core.Contracts;
using Moq;
using NUnit.Framework;
using Providers.Twitter;
using System;
using TweetSharp;

namespace UnitTests.Providers.Twitter
{
    public class TwitterSharerTests
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void GivenNullDependencies_ShouldThrowNullArgsException()
            {
                Assert.Throws<ArgumentNullException>(
                    () => new TwitterSharer(null, null));
            }

            [Test]
            public void GivenNullTwitterService_ShouldThrowNullArgsException()
            {
                var service = new Mock<ITwitterService>();

                Assert.Throws<ArgumentNullException>(
                   () => new TwitterSharer(service.Object, null));
            }

            [Test]
            public void GivenNullCredentialProvider_ShouldThrowNullArgsException()
            {
                var provider = new Mock<ICredentialProvider>();

                Assert.Throws<ArgumentNullException>(
                   () => new TwitterSharer(null, provider.Object));
            }
        }

        [TestFixture]
        public class Authenticate
        {
            [Test]
            public void ShouldCallServiceAuthenticate()
            {
                var service = new Mock<ITwitterService>();
                var provider = new Mock<ICredentialProvider>();
                var sut = new TwitterSharer(service.Object, provider.Object);

                sut.Authenticate();

                service.Verify(
                    (s) =>
                        s.AuthenticateWith(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                            It.IsAny<string>()), Times.Once);
            }

            [Test]
            public void ShouldGetTokenAndSecretsFromCredentialProvider()
            {
                var service = new Mock<ITwitterService>();
                var provider = new Mock<ICredentialProvider>();
                var sut = new TwitterSharer(service.Object, provider.Object);

                sut.Authenticate();

                provider.Verify(
                    (p) =>
                        p.GetToken(), Times.Once);
                provider.Verify(
                    (p) =>
                        p.GetTokenSecret(), Times.Once);
                provider.Verify(
                    (p) =>
                        p.GetConsumerKey(), Times.Once);
                provider.Verify(
                    (p) =>
                        p.GetConsumerSecret(), Times.Once);
            }

            [Test]
            public void ShouldPassAuthValuesInCorrectOrder()
            {
                var service = new Mock<ITwitterService>();
                var provider = new Mock<ICredentialProvider>();
                provider.Setup(p => p.GetConsumerKey()).Returns("CONSUMER_KEY");
                provider.Setup(p => p.GetConsumerSecret()).Returns("CONSUMER_SECRET");
                provider.Setup(p => p.GetToken()).Returns("TOKEN");
                provider.Setup(p => p.GetTokenSecret()).Returns("TOKEN_SECRET");
                var sut = new TwitterSharer(service.Object, provider.Object);

                sut.Authenticate();

                service.Verify(
                    (s) =>
                        s.AuthenticateWith("CONSUMER_KEY", "CONSUMER_SECRET", "TOKEN", "TOKEN_SECRET"),
                    Times.Once);
            }
        }
    }
}