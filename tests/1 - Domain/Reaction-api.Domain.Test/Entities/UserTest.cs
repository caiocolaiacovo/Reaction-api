using Bogus;
using ExpectedObjects;
using Reaction_api.Domain._Exceptions;
using Reaction_api.Domain.Entities;
using Xunit;

namespace Reaction_api.Domain.Test.Entities {
    public class UserTest {
        public Faker faker { get; set; }

        public UserTest () {
            faker = new Faker ();
        }

        [Fact]
        public void Should_create_a_user () {
            var expectedUser = new {
                Name = faker.Person.FullName,
                Profile = faker.Person.UserName,
                Avatar = faker.Internet.Url (),
            };

            var user = new User (expectedUser.Name, expectedUser.Profile, expectedUser.Avatar);

            expectedUser.ToExpectedObject ().ShouldMatch (user);
        }

        [Theory]
        [InlineData (null)]
        [InlineData ("")]
        public void Should_not_create_a_user_without_name (string invalidName) {
            var exception = Assert.Throws<DomainException> (() =>
                new User (invalidName, faker.Person.UserName, faker.Internet.Url ())
            );

            Assert.Equal ("Name is required", exception.Message);
        }

        [Theory]
        [InlineData (null)]
        [InlineData ("")]
        public void Should_not_create_a_user_without_profile (string invalidProfile) {
            var exception = Assert.Throws<DomainException> (() =>
                new User (faker.Person.FullName, invalidProfile, faker.Internet.Url ())
            );

            Assert.Equal ("Profile is required", exception.Message);
        }

        [Theory]
        [InlineData (null)]
        [InlineData ("")]
        public void Should_not_create_a_user_without_avatar (string invalidAvatar) {
            var exception = Assert.Throws<DomainException> (() =>
                new User (faker.Person.FullName, faker.Person.UserName, invalidAvatar)
            );

            Assert.Equal ("Avatar is required", exception.Message);
        }
    }
}