using System;

namespace Core.Contracts
{
    public interface ISharableStrategy
    {
        ISharable Create(Type type);
    }
}