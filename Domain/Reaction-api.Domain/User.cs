using Reaction_api.Domain._Util;
using System.Collections.Generic;

namespace Reaction_api.Domain
{
    public class User : Entity {
        public string Name { get; protected set; }
        public string Profile { get; protected set; }
        public string Avatar { get; protected set; }
        public virtual ICollection<Moment> Moments { get; protected set; }

        protected User() {}

        public User (string name, string profile, string avatar) {
            DomainValidator.New()
                .When(string.IsNullOrWhiteSpace(name), "Name is required")
                .When(string.IsNullOrWhiteSpace(profile), "Profile is required")
                .When(string.IsNullOrWhiteSpace(avatar), "Avatar is required");

            Name = name;
            Profile = profile;
            Avatar = avatar;
            Moments = new List<Moment>();
        }
    }
}