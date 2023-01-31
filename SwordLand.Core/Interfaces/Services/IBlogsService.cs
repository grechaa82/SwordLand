using SwordLand.Core.Models;

namespace SwordLand.Core.Interfaces.Services
{
    public interface IBlogsService
    {
        User[] Get();
        User[] GetById(string postId);
    }
}
