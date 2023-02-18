using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwordLand.API.Contracts;
using SwordLand.API.Models;
using SwordLand.Core.Interfaces.Services;
using SwordLand.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwordLand.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(
            IPostService postService, 
            IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<Post[]> Posts()
        {
            return await _postService.Get();
        }

        [HttpGet("{postId}")]
        public async Task<Post> Post(string postId)
        {
            var result = await _postService.GetById(postId);

            return result;
        }

        [HttpPost("[action]")]
        public async Task<Post> Create(PostRequest post)
        {
            return await _postService.Create(
                post.UserId,
                post.Title,
                post.Content,
                post.Summery,
                post.Category);
        }

        [HttpDelete("{postId}/[action]")]
        public async Task<IActionResult> Delete(string postId)
        {
            await _postService.Delete(postId);
            return Ok();
        }

        [HttpPatch("{postId}/[action]")]
        public async Task<IActionResult> Update(PostRequest post, string postId)
        {
            await _postService.Update(
                postId,
                post.UserId,
                post.Title,
                post.Content,
                post.Summery,
                post.Category);

            return Ok();
        }
    }
}
