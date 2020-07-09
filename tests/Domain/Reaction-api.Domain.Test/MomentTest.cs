using ExpectedObjects;
using Reaction_api.Domain._Exceptions;
using Reaction_api.Domain.Test._Base;
using Reaction_api.Domain.Test._Builders;
using Reaction_api.Domain.Test._Util;
using Xunit;

namespace Reaction_api.Domain.Test
{
    public class MomentTest : UnitTestBase
    {
        private readonly User _user;
        private readonly string _picture;
        private readonly string _description;

        public MomentTest()
        {
            _user = UserBuilder.Instance().Build();
            _picture = "http://localhost/public/photos/123.jpg";
            _description = "This is a description";
        }

        [Fact]
        public void Should_create_a_moment()
        {
            var expectedMoment = new
            {
                User = _user,
                Picture = _picture,
                Description = _description
            };

            var moment = new Moment(expectedMoment.User,
                                    expectedMoment.Picture,
                                    expectedMoment.Description);

            expectedMoment.ToExpectedObject().ShouldMatch(moment);
        }

        [Fact]
        public void Should_not_create_a_moment_without_user()
        {
            const string expectedMessage = "User is required";
            User user = null;

            void Action() => new Moment(user, _picture, _description);

            Assert.Throws<DomainException>(Action).WithMessage(expectedMessage);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Shoud_not_create_a_moment_without_picture(string invalidPicture)
        {
            const string expectedMessage = "Picture is required";

            void Action() => new Moment(_user, invalidPicture, _description);

            Assert.Throws<DomainException>(Action).WithMessage(expectedMessage);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Shoud_not_create_a_moment_without_description(string invalidDescription)
        {
            const string expectedMessage = "Description is required";

            void Action() => new Moment(_user, _picture, invalidDescription);

            Assert.Throws<DomainException>(Action).WithMessage(expectedMessage);
        }

        [Fact]
        public void Should_receive_a_comment()
        {
            var comment = CommentBuilder.Instance().Build();
            var moment = MomentBuilder.Instance().Build();
            var expectedComments = new[] { comment };

            moment.ReceiveComment(comment);

            var comments = moment.Comments;
            expectedComments.ToExpectedObject().ShouldMatch(comments);
        }

        [Fact]
        public void Should_not_receive_a_null_comment()
        {
            const string expectedMessage = "Comment is required";
            var moment = MomentBuilder.Instance().Build();
            Comment comment = null;

            void Action() => moment.ReceiveComment(comment);

            Assert.Throws<DomainException>(Action).WithMessage(expectedMessage);
        }

        [Fact]
        public void Should_receive_a_reaction_from_user()
        {
            var user = UserBuilder.Instance().Build();
            var moment = MomentBuilder.Instance().Build();
            var reaction = new Reaction(user, "Like");
            var expectedReactions = new[] { reaction };

            moment.ReceiveReaction(reaction);

            var reactions = moment.Reactions;
            expectedReactions.ToExpectedObject().ShouldMatch(reactions);
        }

        [Fact]
        public void Should_not_receive_a_null_reaction()
        {
            const string expectedMessage = "Reaction is required";
            var moment = MomentBuilder.Instance().Build();
            Reaction reaction = null;

            void Action() => moment.ReceiveReaction(reaction);

            Assert.Throws<DomainException>(Action).WithMessage(expectedMessage);
        }
    }
}