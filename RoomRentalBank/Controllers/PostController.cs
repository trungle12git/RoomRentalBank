using Microsoft.AspNetCore.Mvc;

namespace RoomRentalBank.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
