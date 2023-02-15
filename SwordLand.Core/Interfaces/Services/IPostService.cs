using SwordLand.Core.Models;
using System.Collections.Generic;

namespace SwordLand.Core.Interfaces.Services
{
    public interface IPostService
    {
        Post[] Get();
        Post GetById(string postId);
        Post Create(string userId, string title, string content, string summery, string category);
        void Update(string id, string userId, string title, string content, string summery, string category);
        void Delete(string postId);
    }
}
