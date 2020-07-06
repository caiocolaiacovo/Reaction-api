using Bogus;
using ExpectedObjects;
using Reaction_api.Domain._Exceptions;
using Reaction_api.Domain;
using Reaction_api.Domain.Test._Builders;
using Xunit;
using Reaction_api.Domain.Test._Util;
using System;
using System.Collections.Generic;

namespace Reaction_api.Domain.Test
{
    public class UserTest
    {
        public Faker faker { get; set; }

        public UserTest()
        {
            faker = new Faker();
        }

        [Fact]
        public void Should_create_a_user()
        {
            var expectedUser = new
            {
                Name = faker.Person.FullName,
                Profile = faker.Person.UserName,
                Avatar = faker.Internet.Url(),
                Moments = new List<Moment>()
            };

            var user = UserBuilder.Instance().WithName(expectedUser.Name).
                  WithProfile(expectedUser.Profile).
                  WithAvatar(expectedUser.Avatar).
                  Build();

            expectedUser.ToExpectedObject().ShouldMatch(user);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Should_not_create_a_user_without_name(string invalidName)
        {
            Action action = () => UserBuilder.Instance().WithName(invalidName).Build();
            
            Assert.Throws<DomainException>(action).WithMessage("Name is required");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Should_not_create_a_user_without_profile(string invalidProfile)
        {
            Action action = () => UserBuilder.Instance().WithProfile(invalidProfile).Build();
            
            Assert.Throws<DomainException>(action).WithMessage("Profile is required");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Should_not_create_a_user_without_avatar(string invalidAvatar)
        {
            Action action = () => UserBuilder.Instance().WithAvatar(invalidAvatar).Build();
            
            Assert.Throws<DomainException>(action).WithMessage("Avatar is required");
        }
    }
}