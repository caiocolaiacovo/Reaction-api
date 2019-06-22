using Bogus;
using Reaction_api.Domain.Entities;

namespace Reaction_api.Domain.Test._Builders
{
    public class UserBuilder
    {
        public string Name;
        public string Profile;
        public string Avatar;
        public static UserBuilder Instancia()
        {
            return new UserBuilder();
        }
        public UserBuilder()
        {
            var faker = new Faker();
            Name = faker.Person.FullName;
            Profile = faker.Person.UserName;
            Avatar = faker.Internet.Url();
        }
        public UserBuilder ComNome(string name)
        {
            Name = name;
            return this;
        }

        public UserBuilder ComProfile(string profile)
        {
            Profile = profile;
            return this;
        }

        public UserBuilder ComAvatar(string avatar)
        {
            Avatar = avatar;
            return this;
        }

        public User Construir()
        {
            return new User(Name, Profile, Avatar);
        }
    }
}