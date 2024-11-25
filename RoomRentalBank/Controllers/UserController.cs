using Microsoft.AspNetCore.Mvc;
using RoomRentalBank.Models;
using RoomRentalBank.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;
using RoomRentalBank.Services;
using RoomRentalBank.ViewModels;

namespace RoomRentalBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Đăng nhập người dùng.
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel loginModel)
        {
            var user = await _userService.AuthenticateAsync(loginModel.Username, loginModel.Password);
            if (user == null)
                return Unauthorized("Tên đăng nhập hoặc mật khẩu không đúng.");

            return Ok(user);
        }


    }
}
