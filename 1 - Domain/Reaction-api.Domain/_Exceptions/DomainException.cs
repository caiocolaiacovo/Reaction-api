using System;

namespace Reaction_api.Domain._Exceptions {
    public class DomainException : Exception {
        public DomainException (string message) : base (message) { }
    }
}