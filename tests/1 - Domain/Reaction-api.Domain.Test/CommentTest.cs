using Bogus;
using ExpectedObjects;
using Reaction_api.Domain._Exceptions;
using Reaction_api.Domain.Test._Builders;
using Xunit;

namespace Reaction_api.Domain.Test
{
    public class CommentTest
    {
        public Faker faker { get; private set; }

        public CommentTest()
        {
            faker = new Faker();
        }

        [Fact]
        public void Should_create_a_comment()
        {
            var expectedComment = new {
                User = UserBuilder.Instance().Build(),
                Text = faker.Lorem.Paragraphs(),
            };

            var comment = new Comment(expectedComment.User, expectedComment.Text);

            expectedComment.ToExpectedObject().ShouldMatch(comment);
        }

        [Fact]
        public void Should_not_create_a_comment_without_user()
        {
            var exception = Assert.Throws<DomainException>(() => 
                CommentBuilder.Instance().WithUser(null).Build()
            );

            Assert.Equal("User is required", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_not_create_a_comment_without_text(string invalidText)
        {
            var exception = Assert.Throws<DomainException>(() => 
                CommentBuilder
                    .Instance()
                    .WithUser(UserBuilder.Instance().Build())
                    .WithText(invalidText)
                    .Build()
            );

            Assert.Equal("Text is required", exception.Message);
        }
    }
}