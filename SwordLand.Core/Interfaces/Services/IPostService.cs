using SwordLand.Core.Models;
using System.Collections.Generic;

namespace SwordLand.Core.Interfaces.Services
{
    public interface IPostService
    {
        IEnumerable<Post> GetById(string postId);
    }
}
