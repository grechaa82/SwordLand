using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SwordLand.Core.Interfaces.Repository;
using SwordLand.Core.Models;
using SwordLand.DataAccess.MSSQL.Entities;
using System;
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
            var result = _context.User.OrderBy(x => x.Rating)
                .Include(x => x.Role)
                .Take(10)
                .AsNoTracking()
                .ToArray();

            return _mapper.Map<UserEntity[], User[]>(result);
        }

        public User GetByName(string name)
        {
            var result = _context.User.Where(x => x.NickName.ToLower() == name.ToLower())
                .AsNoTracking()
                .FirstOrDefault();

            if (result is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return _mapper.Map<UserEntity, User>(result);
        }
    }
}
