using System;

namespace Core.Contracts
{
    public interface ISharableFactory
    {
        ISharable CreateSharer();

        bool AppliesTo(Type type);
    }
}