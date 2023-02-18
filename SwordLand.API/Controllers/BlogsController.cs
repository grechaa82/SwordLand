using Microsoft.AspNetCore.Mvc;
using SwordLand.Core.Interfaces.Services;
using SwordLand.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Blogs()
        {
            var result = await _blogsService.Get();
            return Ok(result);
        }

        [HttpGet("{userNickName}")]
        public async Task<IActionResult> UserBlog(string userNickName)
        {
            var result = await _blogsService.GetByName(userNickName);
            return Ok(result);
        }
    }
}
