using Reaction_api.Domain._Util;

namespace Reaction_api.Domain
{
    public class Comment : Entity
    {
        public User User { get; protected set; }
        public string Text { get; protected set; }

        protected Comment() { }
        
        public Comment(User user, string text)
        {
            DomainValidator.New()
                .When(user == null, "User is required")
                .When(string.IsNullOrWhiteSpace(text),"Text is required");

            User = user;
            Text = text;
        }
    }
}