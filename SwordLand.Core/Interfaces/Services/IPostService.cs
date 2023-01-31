using SwordLand.Core.Models;
using System.Collections.Generic;

namespace SwordLand.Core.Interfaces.Services
{
    public interface IPostService
    {
        Post[] Get();
        Post GetById(string postId);
        Post Create(Post post);
        void Delete(string postId);
    }
}
