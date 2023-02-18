using SwordLand.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwordLand.Core.Interfaces.Repository
{
    public interface IPostRepository
    {
        Task<Post[]> Get();
        Task<Post> GetById(string postId);
        Task<Post> Create(Post post);
        Task Delete(Post post);
        Task<User> GetUser(string userId);
        Task<Category> GetCategory(string category);
        Task Update(Post post);
    }
}
