using Reaction_api.Domain._Exceptions;

namespace Reaction_api.Domain.Entities {
    public class User {
        public string Name { get; private set; }
        public string Profile { get; private set; }
        public string Avatar { get; private set; }

        public User (string name, string profile, string avatar) {
            if (string.IsNullOrEmpty (name))
                throw new DomainException ("Name is required");

            if (string.IsNullOrEmpty (profile))
                throw new DomainException ("Profile is required");

            if (string.IsNullOrEmpty (avatar))
                throw new DomainException ("Avatar is required");

            Name = name;
            Profile = profile;
            Avatar = avatar;
        }
    }
}