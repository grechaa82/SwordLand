using System;
using System.Collections.Generic;

namespace SwordLand.Core.Models
{
    public class Comment
    {
        private Comment(
            Guid id, 
            User user,
            Guid postId, 
            string content, 
            Comment parentComment, 
            DateTime createdAt)
        {
            Id = id;
            User = user;
            PostId= postId;
            Content = content;
            ParentComment = parentComment;
            CreatedAt = createdAt;
        }

        public Guid Id { get; private set; }
        public User User { get; private set; }
        public Guid PostId { get; private set; }
        public string Content { get; private set; }
        public Comment? ParentComment { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public static Comment Create(
            User user,
            Guid postId,
            string content,
            Comment parentComment) 
        {
            if (user is null)
            {
                throw new ArgumentNullException($"{nameof(user)} cannot be null");
            }

            if (postId == Guid.Empty)
            {
                throw new ArgumentNullException($"{nameof(postId)} cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException($"{nameof(content)} is incorrect");
            }

            /*if (parentComment is null)
            {
                throw new ArgumentNullException($"{nameof(parentComment)} cannot be null");
            }*/

            var comment = new Comment(
                Guid.NewGuid(),
                user, 
                postId,
                content,
                parentComment,
                DateTime.Now);

            return comment;
        }
    }
}
