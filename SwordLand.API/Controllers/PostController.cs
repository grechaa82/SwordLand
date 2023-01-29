using Microsoft.AspNetCore.Mvc;
using SwordLand.API.Models;
using SwordLand.Core.Interfaces.Services;
using System.Collections.Generic;

namespace SwordLand.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("{postId}")]
        public IActionResult Post(string postId)
        {
            var post = _postService.GetById(postId);

/*            var result = new PostDTO();*/

            return Ok(post);
        }
    }
}
