using Reaction_api.Domain.Test._Base;

namespace Reaction_api.Domain.Test._Builders
{
    public class MomentBuilder : BuilderBase
    {
        public User User { get; set; }
        public string ElapsedTime;
        public string Picture;
        public string Description;
        public static MomentBuilder Instance()
        {
            return new MomentBuilder();
        }

        public MomentBuilder()
        {
            User = UserBuilder.Instance().Build();
            Picture = faker.Image.PicsumUrl();
            Description = faker.Lorem.Paragraphs();
        }

        public MomentBuilder WithUser(User user)
        {
            User = user;
            return this;
        }
        public Moment Build()
        {
            return new Moment(User, Picture, Description);
        }

        public MomentBuilder WithPicture(string picture)
        {
            Picture = picture;
            return this;
        }

        public MomentBuilder WithDescription(string description)
        {
            Description = description;
            return this;
        }
    }
}