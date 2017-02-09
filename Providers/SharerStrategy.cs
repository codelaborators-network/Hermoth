using Core.Contracts;
using Rework;
using System;
using System.Linq;

namespace Providers
{
    public class SharerStrategy : ISharableStrategy
    {
        private readonly ISharableFactory[] _factories;

        public SharerStrategy(ISharableFactory[] factories)
        {
            Require.NotNull(factories);

            _factories = factories;
        }

        public ISharable Create(Type type)
        {
            var factory = _factories.FirstOrDefault(f => f.AppliesTo(type));

            if (factory == null)
                throw new Exception($"Cannot find factor of type: {type.Namespace}");

            return factory.CreateSharer();
        }
    }
}