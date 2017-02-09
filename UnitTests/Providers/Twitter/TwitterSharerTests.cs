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
    }
}