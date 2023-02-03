using System;

namespace SwordLand.Core.Models
{
    public class Post
    {
        const int MAX_TITLE_LENGTH = 255;
        const int MAX_SUMMERY_LENGTH = 255;

        private Post(
            Guid id,
            User user,
            string title,
            string content,
            string summery,
            Category category,
            string postUrl,
            DateTime createdAt,
            DateTime lastModified,
            bool isPublished = true)
        {
            Id = id;
            User = user;
            Title = title;
            Content = content;
            Summery = summery;
            Category = category;
            PostUrl = postUrl;
            CreatedAt = createdAt;
            IsPublished = isPublished;
            LastModified = lastModified;
        }

        public Guid Id { get; }
        public User User { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string Summery { get; private set; }
        public Category Category { get; private set; }
        public string PostUrl { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsPublished { get; private set; }
        public DateTime LastModified { get; private set; }

        public static Post Create(
            Guid id,
            User user,
            string title,
            string content,
            string summery,
            Category category,
            DateTime createdAt,
            DateTime lastModified,
            bool isPublished = true)
        {
            if (user is null)
            {
                throw new ArgumentNullException($"{nameof(user)} cannot be null");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException($"{nameof(title)} is incorrect");
            }

            if (!string.IsNullOrWhiteSpace(title)
                && title.Length >= MAX_TITLE_LENGTH)
            {
                throw new ArgumentException($"{nameof(title)} is not be more than {MAX_TITLE_LENGTH} chars");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException($"{nameof(content)} is incorrect");
            }

            if (string.IsNullOrWhiteSpace(summery))
            {
                throw new ArgumentNullException($"{nameof(summery)} is incorrect");
            }

            if (!string.IsNullOrWhiteSpace(summery)
                && summery.Length >= MAX_SUMMERY_LENGTH)
            {
                throw new ArgumentException($"{nameof(summery)} is not be more than {MAX_SUMMERY_LENGTH} chars");
            }

            if (category is null)
            {
                throw new ArgumentNullException($"{nameof(category)} cannot be null");
            }

            var postUrl = "Post" + id;

            var post = new Post(
                id,
                user,
                title,
                content,
                summery,
                category,
                postUrl,
                createdAt,
                lastModified,
                isPublished);

            return post; 
        }
    }
}
