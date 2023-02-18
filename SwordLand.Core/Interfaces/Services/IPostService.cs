using SwordLand.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwordLand.Core.Interfaces.Services
{
    public interface IPostService
    {
        Task<Post[]> Get();
        Task<Post> GetById(string postId);
        Task<Post> Create(string userId, string title, string content, string summery, string category);
        Task Update(string id, string userId, string title, string content, string summery, string category);
        Task Delete(string postId);
    }
}
