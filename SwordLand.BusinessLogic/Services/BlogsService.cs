using SwordLand.Core.Interfaces.Repository;
using SwordLand.Core.Interfaces.Services;
using SwordLand.Core.Models;

namespace SwordLand.BusinessLogic.Services
{
    public class BlogsService : IBlogsService
    {
        private readonly IBlogsRepository _blogsRepository;

        public BlogsService(IBlogsRepository blogsRepository)
        {
            _blogsRepository = blogsRepository;
        }

        public User[] Get()
        {
            return _blogsRepository.Get();
        }

        public User GetByName(string name)
        {
            return _blogsRepository.GetByName(name);
        }
    }
}
