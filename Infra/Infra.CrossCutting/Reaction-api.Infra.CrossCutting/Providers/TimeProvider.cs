using System;

namespace Reaction_api.Infra.CrossCutting.Providers
{
    public abstract class TimeProvider
    {
        private static TimeProvider _current;
        public abstract DateTime Now { get; }

        public static TimeProvider Current
        {
            get => _current;
            set => _current = value ?? throw new ArgumentNullException("value");
        }
    }
}
