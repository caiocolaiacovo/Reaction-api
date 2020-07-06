using Reaction_api.Domain.Test._Base;

namespace Reaction_api.Domain.Test._Builders
{
    public class CommentBuilder : BuilderBase
    {
        public User User { get; private set; }
        public string Text { get; private set; }

        public static CommentBuilder Instance()
        {
            return new CommentBuilder();
        }

        public CommentBuilder()
        {
            User = UserBuilder.Instance().Build();
            Text = faker.Lorem.Paragraphs();
        }

        public CommentBuilder WithUser(User user)
        {
            User = user;
            return this;
        }

        public CommentBuilder WithText(string text)
        {
            Text = text;
            return this;
        }

        public Comment Build()
        {
            return new Comment(User, Text);
        }
    }
}