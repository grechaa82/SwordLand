using System;
using System.Collections.Generic;

namespace SwordLand.Core.Models
{
    public class Comment
    {
        private Comment(
            Guid id, 
            User user, 
            Post post, 
            string content, 
            Comment parentComment, 
            DateTime createdAt)
        {
            Id = id;
            User = user;
            Post = post;
            Content = content;
            ParentComment = parentComment;
            CreatedAt = createdAt;
        }

        public Guid Id { get; private set; }
        public User User { get; private set; }
        public Post Post { get; private set; }
        public string Content { get; private set; }
        public Comment? ParentComment { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public static Comment Create(
            User user,
            Post post,
            string content,
            Comment parentComment) 
        {
            if (user is null)
            {
                throw new ArgumentNullException($"{nameof(user)} cannot be null");
            }

            if (post is null)
            {
                throw new ArgumentNullException($"{nameof(post)} cannot be null");
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
                post,
                content,
                parentComment,
                DateTime.Now);

            return comment;
        }
    }
}
