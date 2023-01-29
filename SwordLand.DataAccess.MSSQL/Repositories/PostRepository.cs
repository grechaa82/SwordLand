using AutoMapper;
using SwordLand.Core.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SwordLand.DataAccess.MSSQL.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SwordLandDbContext _context;
        private readonly IMapper _mapper;

        public PostRepository(SwordLandDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Core.Models.Post> GetById(string postId)
        {
            var post = _context.Post.Where(x => x.Id.ToString() == postId).AsEnumerable();
            IEnumerable<Core.Models.Post> result = _mapper.Map<Entities.Post, IEnumerable<Core.Models.Post>>((Entities.Post)post);

            return result;
        }
    }
}
