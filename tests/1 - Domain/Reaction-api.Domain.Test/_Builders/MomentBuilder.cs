
using Reaction_api.Domain;

namespace Reaction_api.Domain.Test._Builders
{
    public class MomentBuilder
    {
        public User User { get; set; }
        public string ElapsedTime;
        public string Picture;
        public int Reactions;
        public static MomentBuilder Instance()
        {
            return new MomentBuilder();
        }

        public MomentBuilder WithUser(User user)
        {
            User = user;
            return this;
        }
        public Moment Build()
        {
            return new Moment(User, ElapsedTime, Picture, Reactions);
        }

    }
}