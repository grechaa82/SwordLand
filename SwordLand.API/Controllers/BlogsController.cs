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
        public IActionResult Blogs()
        {
            var result = _blogsService.Get();
            return Ok(result);
        }

        [HttpGet("{userNickName}")]
        public IActionResult UserBlog(string userNickName)
        {
            var result = _blogsService.GetByName(userNickName);
            return Ok(result);
        }
    }
}
