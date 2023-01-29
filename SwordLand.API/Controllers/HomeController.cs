using Microsoft.AspNetCore.Mvc;
using SwordLand.Core.Interfaces.Services;

namespace SwordLand.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return null;
        }
    }
}
