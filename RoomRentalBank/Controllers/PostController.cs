using Microsoft.AspNetCore.Mvc;
using RoomRentalBank.Models;
using RoomRentalBank.Interfaces;
using RoomRentalBank.Services;
using System.Diagnostics;
using RoomRentalBank.ViewModels;

namespace RoomRentalBank.Controllers
{
    public class PostController : Controller
    {
        public IActionResult NewPost()
        {
            return View();
        }
    }
}
