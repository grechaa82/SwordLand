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
        
        public Post Create(
            string userId, 
            string title, 
            string content, 
            string summery, 
            string category)
        {
            var User = _postRepository.GetUser(userId);
            var Category = _postRepository.GetCategory(category);
            
            var guid = Guid.NewGuid();
            var date = DateTime.Now;

            var result = Post.Create(
                guid, 
                User,
                title,
                content,
                summery,
                Category,
                date,
                date,
                default);

            return _postRepository.Create(result);
        }

        public void Delete(string postId)
        {
            var post = _postRepository.GetById(postId);

            if (post is null)
            {
                throw new ArgumentNullException(nameof(post));
            }

            var deletedPost = Post.Create(
                post.Id,
                post.User,
                post.Title,
                post.Content,
                post.Summery,
                post.Category,
                post.CreatedAt,
                DateTime.Now,
                false);

            _postRepository.Delete(deletedPost);
        }

        public void Update(string id, string userId, string title, string content, string summery, string category)
        {
            var post = _postRepository.GetById(id);

            if (post is null)
            {
                throw new ArgumentNullException(nameof(post));
            }

            var updatedPost = Post.Create(
                post.Id,
                post.User,
                title,
                content,
                summery,
                post.Category,
                post.CreatedAt,
                DateTime.Now,
                default);

            _postRepository.Update(updatedPost);
        }
    }
}
