using Core.Contracts;
using Rework;
using TweetSharp;

namespace Providers.Twitter
{
    public class TwitterSharer : ISharable
    {
        private readonly ITwitterService _service;
        private readonly ICredentialProvider _credProvider;

        public TwitterSharer(ITwitterService service, ICredentialProvider credProvider)
        {
            Require.NotNull(service);
            Require.NotNull(credProvider);

            _service = service;
            _credProvider = credProvider;
        }

        public void Authenticate()
        {
            string token = _credProvider.GetToken();
            string tokenSecret = _credProvider.GetTokenSecret();
            string consumerKey = _credProvider.GetConsumerKey();
            string consumerSecret = _credProvider.GetConsumerSecret();

            _service.AuthenticateWith(consumerKey, consumerSecret, token, tokenSecret);
        }

        public void Share(string content)
        {
            var result = _service.SendTweet(new SendTweetOptions()
            {
                Status = content
            });
        }
    }
}