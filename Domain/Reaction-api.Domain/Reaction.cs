using Reaction_api.Domain._Util;

namespace Reaction_api.Domain
{
    public class Reaction
    {
        public User User { get; protected set; }
        public string Type { get; protected set; }

        public Reaction(User user, string type)
        {
            DomainValidator.New()
                .When(user == null, "User is required")
                .When(string.IsNullOrWhiteSpace(type), "Type is required");

            User = user;
            Type = type;
        }
    }
}
