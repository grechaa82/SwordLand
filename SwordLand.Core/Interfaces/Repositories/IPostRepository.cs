using SwordLand.Core.Models;
using System;
using System.Collections.Generic;

namespace SwordLand.Core.Interfaces.Repository
{
    public interface IPostRepository
    {
        Post[] Get();
        Post GetById(string postId);
        Post Create(Post post);
        void Delete(Post post);
        User GetUser(string userId);
        Category GetCategory(string category);
        void Update(Post post);
    }
}
