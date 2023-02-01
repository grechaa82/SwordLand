using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwordLand.API.Contracts;
using SwordLand.API.Models;
using SwordLand.Core.Interfaces.Services;
using SwordLand.Core.Models;

namespace SwordLand.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public Post[] Posts()
        {
            return _postService.Get();
        }

        [HttpGet("{postId}")]
        public (Post, Comment[]) Post(string postId)
        {
            return _postService.GetById(postId);
        }

        [HttpPost("[action]")]
        public Post Create(PostRequest post)
        {
            var result = _mapper.Map<PostRequest, Post>(post);

            return _postService.Create(result);
        }

        [HttpDelete("{postId}/[action]")]
        public IActionResult Delete(string postId)
        {
            _postService.Delete(postId);
            return Ok();
        }

        [HttpPatch("{postId}/[action]")]
        public IActionResult Update(PostRequest post)
        {
            
            return Ok();
        }
    }
}
