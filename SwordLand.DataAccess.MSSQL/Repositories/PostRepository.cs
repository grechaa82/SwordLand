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

        public PostRepository(
            SwordLandDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Post[] Get()
        {
            var posts = _context.Post
                .Where(x => x.IsPublished == true)
                .Include(x => x.User)
                .Include(x => x.Category)
                .Take(20)
                .AsNoTracking()
                .ToArray();

            return _mapper.Map<PostEntity[], Post[]>(posts);
        }

        public Post GetById(string postId)
        {
            var posts = _context.Post
                .Where(x => x.IsPublished == true && x.Id.ToString() == postId)
                .Include(x => x.User)
                .Include(x => x.Category)
                .AsNoTracking()
                .FirstOrDefault();

            return _mapper.Map<PostEntity, Post>(posts);
        }

        public List<Comment> GetCommentsById(string postId)
        {
            var comments = _context.Comment
                .Include(x => x.User)
                .Include(x => x.Post)
                .Where(x => x.Post.Id.ToString() == postId)
                .AsNoTracking()
                .ToList();

            return _mapper.Map<List<CommentEntity>, List<Comment>>(comments);
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
            var result = _context.User
                .AsNoTracking()
                .FirstOrDefault(x => x.Id.ToString() == userId);

            if (result is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _mapper.Map<UserEntity, User>(result);
        }

        public Category GetCategory(string category)
        {
            var result = _context.Category
                .AsNoTracking()
                .FirstOrDefault(x => x.Title == category);

            if (result is null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            return _mapper.Map<CategoryEntity, Category>(result);
        }

        public void Update(Post post)
        {
            var result = _mapper.Map<Post, PostEntity>(post);

            using (_context)
            {
                _context.Update(result);

                _context.SaveChanges();
            }
        }
    }
}
