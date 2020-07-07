using ExpectedObjects;
using Reaction_api.Domain._Exceptions;
using Reaction_api.Domain.Test._Util;
using System.Collections.Generic;
using Xunit;

namespace Reaction_api.Domain.Test
{
    public class UserTest
    {
        private readonly string _name;
        private readonly string _profile;
        private readonly string _avatar;

        public UserTest()
        {
            _name = "Caio Colaiacovo Carneiro da Costa";
            _profile = "caiocolaiacovo";
            _avatar = "http://localhost/photo/avatar.jpg";
        }

        [Fact]
        public void Should_create_a_user()
        {
            var expectedUser = new
            {
                Name = _name,
                Profile = _profile,
                Avatar = _avatar,
                Moments = new List<Moment>()
            };

            var user = new User(expectedUser.Name, expectedUser.Profile, expectedUser.Avatar);

            expectedUser.ToExpectedObject().ShouldMatch(user);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Should_not_create_a_user_with_invalid_name(string invalidName)
        {
            void Action() => new User(invalidName, _profile, _avatar);
            
            Assert.Throws<DomainException>(Action).WithMessage("Name is required");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Should_not_create_a_user_with_invalid_profile(string invalidProfile)
        {
            void Action() => new User(_name, invalidProfile, _avatar);

            Assert.Throws<DomainException>(Action).WithMessage("Profile is required");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Should_not_create_a_user_with_invalid_avatar(string invalidAvatar)
        {
            void Action() => new User(_name, _profile, invalidAvatar);

            Assert.Throws<DomainException>(Action).WithMessage("Avatar is required");
        }
    }
}