using System;

namespace Reaction_api.Infra.CrossCutting.Providers
{
    public class DefaultTimeProvider : TimeProvider
    {
        public override DateTime Now => DateTime.Now;

        static DefaultTimeProvider()
        {
            Current = new DefaultTimeProvider();
        }
    }
}
