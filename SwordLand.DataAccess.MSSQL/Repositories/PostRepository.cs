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
    public class PostRepository : IPostRepository
    {
        private readonly SwordLandDbContext _context;
        private readonly IMapper _mapper;

        public PostRepository(SwordLandDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Post[] Get()
        {
            var posts = _context.Post.Where(x => x.IsPublished == true)
                .Include(x => x.User)
                .Include(x => x.Category)
                .Take(20)
                .AsNoTracking()
                .ToArray();

            return _mapper.Map<PostEntity[], Post[]>(posts);
        }

        public Post GetById(string postId)
        {
            var posts = _context.Post.Where(x => x.IsPublished == true && x.Id.ToString() == postId)
                .Include(x => x.User)
                .Include(x => x.Category)
                .AsNoTracking()
                .FirstOrDefault();

            return _mapper.Map<PostEntity, Post>(posts);
        }

        public Post Create(Post post)
        {
            var result = _mapper.Map<Post, PostEntity>(post);

            using (_context)
            {
                _context.Post.Add(result);

                _context.SaveChanges();
            }

            return post;
        }

        public void Delete(Post post)
        {
            var result = _mapper.Map<Post, PostEntity>(post);

            using (_context)
            {
                _context.Update(result);

                _context.SaveChanges();
            }
        }

        public User GetUser(string userId)
        {
            //TODO: Return an error if the user is not found

            var result = _context.User.Where(x => x.Id.ToString() == userId)
                .First();

            return _mapper.Map<UserEntity, User>(result);
        }
    }
}
