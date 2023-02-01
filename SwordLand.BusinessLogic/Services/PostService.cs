using SwordLand.Core.Interfaces.Repository;
using SwordLand.Core.Interfaces.Services;
using SwordLand.Core.Models;
using System;
using System.Collections.Generic;

namespace SwordLand.BusinessLogic.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Post[] Get()
        {
            return _postRepository.Get();
        }

        public (Post, Comment[]) GetById(string postId)
        {
            var post = _postRepository.GetById(postId);
            var comments = _postRepository.GetCommentsById(postId);

            return (post, comments);
        }
        
        public Post Create(Post post)
        {
            var guid = Guid.NewGuid();
            var date = DateTime.Now;

            // TODO: check if the user exists
            var user = _postRepository.GetUser(post.UserId.ToString());

            Post result = new Post
            {
                Id = guid,
                User = user,
                Title = post.Title,
                Content = post.Content,
                Summery = post.Summery,
                Category = post.Category,
                PostUrl = "Post/"+guid.ToString(),
                CreatedAt = date,
                IsPublished = true,
                LastModified = date
            };

            return _postRepository.Create(result);
        }

        public void Delete(string postId)
        {
            var post = _postRepository.GetById(postId);

            Post result = new Post
            {
                Id = post.Id,
                User = post.User,
                Title = post.Title,
                Content = post.Content,
                Summery = post.Summery,
                Category = post.Category,
                PostUrl = post.PostUrl,
                CreatedAt = post.CreatedAt,
                IsPublished = false,
                LastModified = DateTime.Now
            };

            _postRepository.Delete(result);
        }
    }
}
