namespace Core.Contracts
{
    public interface ISharable
    {
        void Authenticate();

        void Share(string content);
    }
}