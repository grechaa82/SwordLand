using SwordLand.Core.Interfaces.Repository;
using SwordLand.Core.Interfaces.Services;
using SwordLand.Core.Models;
using System.Threading.Tasks;

namespace SwordLand.BusinessLogic.Services
{
    public class BlogsService : IBlogsService
    {
        private readonly IBlogsRepository _blogsRepository;

        public BlogsService(IBlogsRepository blogsRepository)
        {
            _blogsRepository = blogsRepository;
        }

        public async Task<User[]> Get()
        {
            return await _blogsRepository.Get();
        }

        public async Task<User> GetByName(string name)
        {
            return await _blogsRepository.GetByName(name);
        }
    }
}
