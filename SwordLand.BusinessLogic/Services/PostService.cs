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

        public (Post, List<Comment>) GetById(string postId)
        {
            var post = _postRepository.GetById(postId);
            var comments = _postRepository.GetCommentsById(postId);

            //TODO: Добавить в модель Post ICollection<Comment> и вставить туда комменты. Лучше сделать на слое с базой данных

            return (post, comments);
        }
        
        public Post Create(string userId, string title, string content, string summery, string category)
        {
            var user = _postRepository.GetUser(userId);
            var _category = _postRepository.GetCategory(category);
            
            var guid = Guid.NewGuid();
            var date = DateTime.Now;

            var result = Post.Create(
                guid, 
                user,
                title,
                content,
                summery,
                _category,
                date,
                date);

            return _postRepository.Create(result);
        }

        public void Delete(string postId)
        {
            var post = _postRepository.GetById(postId);

            /*Post result = new Post
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
            };*/

            _postRepository.Delete(null);
        }
    }
}
