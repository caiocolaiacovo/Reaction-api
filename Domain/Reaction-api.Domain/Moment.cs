using Reaction_api.Domain._Exceptions;
using Reaction_api.Domain._Util;
using System;
using System.Collections.Generic;

namespace Reaction_api.Domain
{
    public class Moment : Entity
    {
        public User User { get; protected set; }
        public string Picture { get; protected set; }
        public string Description { get; protected set; }
        public virtual ICollection<Comment> Comments { get; protected set; }
        public virtual ICollection<Reaction> Reactions { get; protected set; }

        protected Moment() {}

        public Moment(User user, string picture, string description)
        {
            DomainValidator.New()
                .When(user == null, "User is required")
                .When(string.IsNullOrWhiteSpace(picture), "Picture is required")
                .When(string.IsNullOrWhiteSpace(description), "Description is required");
            
            User = user;
            Picture = picture;
            Description = description;
            Comments = new List<Comment>();
            Reactions = new List<Reaction>();
        }

        public void ReceiveComment(Comment comment)
        {
            if (comment == null)
                throw new DomainException("Comment is required");

            Comments.Add(comment);
        }

        public void ReceiveReaction(Reaction reaction)
        {
            if (reaction == null)
                throw new DomainException("Reaction is required");

            Reactions.Add(reaction);
        }
    }
}