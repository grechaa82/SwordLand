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

        public IEnumerable<Post> GetById(string postId)
        {
            var result = _postRepository.GetById(postId);
            return result;
        }
    }
}
