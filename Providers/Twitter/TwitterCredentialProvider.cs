using Core.Contracts;
using System.Configuration;

namespace Providers.Twitter
{
    public class TwitterCredentialProvider : ICredentialProvider
    {
        public string GetToken()
        {
            return ConfigurationManager.AppSettings["token"];
        }

        public string GetTokenSecret()
        {
            return ConfigurationManager.AppSettings["tokenSecret"];
        }

        public string GetConsumerKey()
        {
            return ConfigurationManager.AppSettings["consumerKey"];
        }

        public string GetConsumerSecret()
        {
            return ConfigurationManager.AppSettings["consumerSecret"];
        }
    }
}