using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SwordLand.Core.Interfaces.Repository;
using SwordLand.Core.Models;
using SwordLand.DataAccess.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwordLand.DataAccess.MSSQL.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SwordLandDbContext _context;
        private readonly IMapper _mapper;

        public PostRepository(
            SwordLandDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Post[]> Get()
        {
            var posts = await _context.Post
                .Where(x => x.IsPublished == true)
                .Include(x => x.User)
                .Include(x => x.Category)
                .Take(20)
                .AsNoTracking()
                .ToArrayAsync();

            return _mapper.Map<PostEntity[], Post[]>(posts);
        }

        public async Task<Post> GetById(string postId)
        {
            var post = await _context.Post
                .Where(x => x.IsPublished == true && x.Id.ToString() == postId)
                .Include(x => x.User)
                .Include(x => x.Category)
                .Include(x => x.Comments)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (post == null)
            {
                throw new ArgumentNullException($"{nameof(post)} is incorrect");
            }

            return _mapper.Map<PostEntity, Post>(post);
        }

        public async Task<Post> Create(Post post)
        {
            var result = _mapper.Map<Post, PostEntity>(post);

            using (_context)
            {
                await _context.Post.AddAsync(result);

                await _context.SaveChangesAsync();
            }

            return post;
        }

        public async Task Delete(Post post)
        {
            var result = _mapper.Map<Post, PostEntity>(post);

            using (_context)
            {
                _context.Update(result);
                
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUser(string userId)
        {
            var result = await _context.User
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.ToString() == userId);

            if (result is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _mapper.Map<UserEntity, User>(result);
        }

        public async Task<Category> GetCategory(string category)
        {
            var result = await _context.Category
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Title == category);

            if (result is null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            return _mapper.Map<CategoryEntity, Category>(result);
        }

        public async Task Update(Post post)
        {
            var result = _mapper.Map<Post, PostEntity>(post);

            using (_context)
            {
                _context.Update(result);

                await _context.SaveChangesAsync();
            }
        }
    }
}
