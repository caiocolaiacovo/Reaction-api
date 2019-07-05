using Reaction_api.Domain._Exceptions;

namespace Reaction_api.Domain
{
    public class Comment
    {
        public User User { get; private set; }
        public string Text { get; private set; }

        public Comment(User user, string text)
        {
            if (user == null)
                throw new DomainException("User is required");
            
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text.Trim()))
                throw new DomainException("Text is required");

            User = user;
            Text = text;
        }
    }
}