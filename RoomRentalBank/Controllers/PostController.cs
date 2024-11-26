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
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }
        public IActionResult NewPost()
        {
            return View();
        }

        [HttpPost]
        [Route("Post/NewPostAsync")] // Đảm bảo route khớp với URL trong Fetch API
        public async Task<IActionResult> NewPostAsync([FromBody] Post post)
        {
            if (post == null)
            {
                return Json(new { success = false, message = "Dữ liệu không hợp lệ!" });
            }

            try
            {
                // Gán thêm thông tin bổ sung
                post.UserId = 1;
                post.Status = 1;
                post.EawCharge = 10000;
                post.CreationDate = DateTime.Now;
                post.UpdationDate = DateTime.Now;

                await _postService.AddPostAsync(post); // Thêm bài đăng thông qua Service
                return Json(new { success = true, message = "Thêm bài đăng thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
            }
        }


    }
}
