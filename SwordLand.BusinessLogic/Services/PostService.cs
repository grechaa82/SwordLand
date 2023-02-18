    using SwordLand.Core.Interfaces.Repository;
using SwordLand.Core.Interfaces.Services;
using SwordLand.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwordLand.BusinessLogic.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post[]> Get()
        {
            return await _postRepository.Get();
        }

        public async Task<Post> GetById(string postId)
        {
            var post = await _postRepository.GetById(postId);

            if (post == null)
            {
                throw new ArgumentNullException($"{nameof(post)} is incorrect");
            }

            return post;
        }
        
        public async Task<Post> Create(
            string userId, 
            string title, 
            string content, 
            string summery, 
            string category)
        {
            var User = await _postRepository.GetUser(userId);
            var Category = await _postRepository.GetCategory(category);
            
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

            return await _postRepository.Create(result);
        }

        public async Task Delete(string postId)
        {
            var post = await _postRepository.GetById(postId);

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

            await _postRepository.Delete(deletedPost);
        }

        public async Task Update(
            string id, 
            string userId, 
            string title, 
            string content, 
            string summery, 
            string category)
        {
            var post = await _postRepository.GetById(id);

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

            await _postRepository.Update(updatedPost);
        }
    }
}
