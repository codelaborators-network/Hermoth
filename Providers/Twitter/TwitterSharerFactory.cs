using Core.Contracts;
using Rework;
using System;
using TweetSharp;

namespace Providers.Twitter
{
    public class TwitterSharerFactory : ISharableFactory
    {
        private readonly ITwitterService _service;
        private readonly ICredentialProvider _credProvider;

        public TwitterSharerFactory(ITwitterService service, ICredentialProvider credProvider)
        {
            Require.NotNull(service);
            Require.NotNull(credProvider);

            _service = service;
            _credProvider = credProvider;
        }

        public ISharable CreateSharer()
        {
            return new TwitterSharer(_service, _credProvider);
        }

        public bool AppliesTo(Type type) => typeof(TwitterSharer).Equals(type);
    }
}