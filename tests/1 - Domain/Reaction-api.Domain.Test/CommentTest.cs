using System;
using ExpectedObjects;
using Reaction_api.Domain._Exceptions;
using Reaction_api.Domain.Test._Base;
using Reaction_api.Domain.Test._Builders;
using Reaction_api.Domain.Test._Util;
using Xunit;

namespace Reaction_api.Domain.Test
{
    public class CommentTest : UnitTestBase
    {
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
            const string expectedMessage = "User is required";

            Action action = () => CommentBuilder.Instance().WithUser(null).Build();

            Assert.Throws<DomainException>(action).WithMessage(expectedMessage);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_not_create_a_comment_with_invalid_text(string invalidText)
        {
            const string expectedMessage = "Text is required";

            Action action = () => CommentBuilder
                .Instance()
                .WithUser(UserBuilder.Instance().Build())
                .WithText(invalidText)
                .Build();

            Assert.Throws<DomainException>(action).WithMessage(expectedMessage);
        }
    }
}