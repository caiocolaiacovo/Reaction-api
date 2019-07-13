using ExpectedObjects;
using Reaction_api.Domain._Exceptions;
using Reaction_api.Domain.Test._Builders;
using Xunit;
using Reaction_api.Domain.Test._Base;
using System;
using Reaction_api.Domain.Test._Util;

namespace Reaction_api.Domain.Test
{
    public class MomentTest : UnitTestBase
    {
        [Fact]
        public void Should_create_a_moment()
        {
            var expectedMoment = new
            {
                User = UserBuilder.Instance().Build(),
                Picture = faker.Internet.Url(),
                Description = faker.Lorem.Paragraph()
            };

            var moment = new Moment(expectedMoment.User,
                                    expectedMoment.Picture,
                                    expectedMoment.Description);

            expectedMoment.ToExpectedObject().ShouldMatch(moment);
        }

        [Fact]
        public void Should_not_create_a_moment_without_user()
        {
            var expectedMessage = "User is required";

            Action action = () => MomentBuilder.Instance().WithUser(null).Build();
            
            Assert.Throws<DomainException>(action).WithMessage(expectedMessage);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Shoud_not_create_a_moment_with_invalid_picture(string invalidPicture)
        {
            var expectedMessage = "Picture is required";

            Action action = () => MomentBuilder.Instance().WithPicture(invalidPicture).Build();
            
            Assert.Throws<DomainException>(action).WithMessage(expectedMessage);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Shoud_not_create_a_moment_with_invalid_description(string invalidDescription)
        {
            var expectedMessage = "Description is required";

            Action action = () => MomentBuilder.Instance().WithDescription(invalidDescription).Build();
            
            Assert.Throws<DomainException>(action).WithMessage(expectedMessage);
        }

        [Fact]
        public void Should_add_comment_to_a_moment()
        {
            var comment = CommentBuilder.Instance().Build();
            var moment = MomentBuilder.Instance().Build();
            var expectedComments = new[] { comment };

            moment.AddComment(comment);

            var comments = moment.Comments;
            expectedComments.ToExpectedObject().ShouldMatch(comments);
        }

        [Fact]
        public void Should_not_add_a_null_comment()
        {
            var expectedMessage = "Comment is required";
            var moment = MomentBuilder.Instance().Build();

            Action action = () => moment.AddComment(null);

            Assert.Throws<DomainException>(action).WithMessage(expectedMessage);
        }
    }
}