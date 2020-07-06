using System.Collections;
using System.Collections.Generic;
using Reaction_api.Domain._Util;

namespace Reaction_api.Domain
{
    public class User : Entity {
        public string Name { get; private set; }
        public string Profile { get; private set; }
        public string Avatar { get; private set; }
        public virtual ICollection<Moment> Moments { get; private set; }

        protected User() {}

        public User (string name, string profile, string avatar) {
            DomainValidator.New()
                .When(string.IsNullOrEmpty(name) || name.Trim() == string.Empty, "Name is required")
                .When(string.IsNullOrEmpty(profile) || profile.Trim() == string.Empty, "Profile is required")
                .When(string.IsNullOrEmpty(avatar) || avatar.Trim() == string.Empty, "Avatar is required");

            Name = name;
            Profile = profile;
            Avatar = avatar;
            Moments = new List<Moment>();
        }
    }
}