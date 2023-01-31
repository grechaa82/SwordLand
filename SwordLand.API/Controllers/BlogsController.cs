using Microsoft.AspNetCore.Mvc;
using SwordLand.Core.Interfaces.Services;
using SwordLand.Core.Models;
using System.Collections.Generic;

namespace SwordLand.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogsController : Controller
    {
        private readonly IBlogsService _blogsService;

        public BlogsController(IBlogsService blogsService)
        {
            _blogsService = blogsService;
        }

        [HttpGet]
        public User[] Blogs()
        {
            return _blogsService.Get();
        }

        [HttpGet("{postId}")]
        public User[] UserBlog(string postId)
        {
            return _blogsService.GetById(postId);
        }
    }
}
