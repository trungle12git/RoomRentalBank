using Microsoft.AspNetCore.Mvc;
using RoomRentalBank.Models;
using RoomRentalBank.Interfaces;
using RoomRentalBank.Services;
using System.Diagnostics;
using RoomRentalBank.ViewModels;

namespace RoomRentalBank.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PostService _postService;

        public HomeController(ILogger<HomeController> logger, PostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetAllPostsAsync();
            
            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
