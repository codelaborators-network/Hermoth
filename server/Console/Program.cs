using Core.Contracts;
using Providers;
using Providers.Twitter;
using TweetSharp;
using static System.Console;

namespace Console
{
    internal class Program
    {
        private static readonly ICredentialProvider TwitterCredentialProvider = new TwitterCredentialProvider();

        private static readonly ISharableStrategy Strategy = new SharerStrategy(new ISharableFactory[]
                {
                    new TwitterSharerFactory(new TwitterService(), new TwitterCredentialProvider())
                });

        private static void Main(string[] args)
        {
            var twitter = Strategy.Create(typeof(TwitterSharer));

            twitter.Authenticate();
            twitter.Share("This is a test tweet");

            ReadLine();
        }
    }
}