using Bogus;
using Reaction_api.Domain;

namespace Reaction_api.Domain.Test._Builders
{
    public class UserBuilder
    {
        public string Name;
        public string Profile;
        public string Avatar;
        public static UserBuilder Instance()
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
        public UserBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public UserBuilder WithProfile(string profile)
        {
            Profile = profile;
            return this;
        }

        public UserBuilder WithAvatar(string avatar)
        {
            Avatar = avatar;
            return this;
        }

        public User Build()
        {
            return new User(Name, Profile, Avatar);
        }
    }
}