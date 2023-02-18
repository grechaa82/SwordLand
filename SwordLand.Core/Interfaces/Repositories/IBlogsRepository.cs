using SwordLand.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwordLand.Core.Interfaces.Repository
{
    public interface IBlogsRepository
    {
        Task<User[]> Get();
        Task<User> GetByName(string name);
    }
}
