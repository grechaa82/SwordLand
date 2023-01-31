using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SwordLand.Core.Interfaces.Repository;
using SwordLand.Core.Models;
using SwordLand.DataAccess.MSSQL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SwordLand.DataAccess.MSSQL.Repositories
{
    public class BlogsRepository : IBlogsRepository
    {
        private readonly SwordLandDbContext _context;
        private readonly IMapper _mapper;

        public BlogsRepository(SwordLandDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public User[] Get()
        {
            var blogs = _context.User.OrderBy(x => x.Rating)
                .Include(x => x.Role)
                .Take(10)
                .AsNoTracking()
                .ToArray();

            return _mapper.Map<UserEntity[], User[]>(blogs);
        }

        public User[] GetById(string userId)
        {
            var blog = _context.User.Where(x => x.Id.ToString() == userId)
                .AsNoTracking()
                .ToArray();

            return _mapper.Map<UserEntity[], User[]>(blog);
        }
    }
}
