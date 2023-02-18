using SwordLand.Core.Models;
using System.Threading.Tasks;

namespace SwordLand.Core.Interfaces.Services
{
    public interface IBlogsService
    {
        Task<User[]> Get();
        Task<User> GetByName(string name);
    }
}
