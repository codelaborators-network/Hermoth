namespace Core.Contracts
{
    public interface ICredentialProvider
    {
        string GetToken();

        string GetTokenSecret();

        string GetConsumerKey();

        string GetConsumerSecret();
    }
}