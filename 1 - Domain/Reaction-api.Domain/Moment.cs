using Reaction_api.Domain._Exceptions;

namespace Reaction_api.Domain
{
    public class Moment
    {
        public User User { get; private set; }
        public string ElapsedTime { get; private set; }
        public string Picture { get; private set; }
        public int Reactions { get; private set; }

        public Moment(User user, string elapsedTime, string picture, int reactions)
        {
            if (user == null)
                throw new DomainException("User is required");
            
            User = user;
            ElapsedTime = elapsedTime;
            Picture = picture;
            Reactions = reactions;
        }
    }
}