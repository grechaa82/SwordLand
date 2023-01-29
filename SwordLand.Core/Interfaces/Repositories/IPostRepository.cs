using SwordLand.Core.Models;
using System.Collections.Generic;

namespace SwordLand.Core.Interfaces.Repository
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetById(string postId);
    }
}
