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

        [HttpDelete]
        [Route("Post/DeletePost/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result = await _postService.DeletePostAsync(id);
            if (!result)
                return BadRequest(new { success = false, message = "Xóa thất bại." });

            return Ok(new { success = true, message = "Xóa thành công." });
        }

        [HttpGet]
        [Route("Post/GetPostById/{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
                return NotFound(new { success = false, message = "Không tìm thấy bài đăng." });

            return Json(post);
        }

        [HttpPut]
        [Route("Post/UpdatePost/{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] Post updatedPost)
        {
            if (updatedPost == null)
            {
                return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ." });
            }

            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound(new { success = false, message = "Không tìm thấy bài đăng." });
            }

            // Cập nhật bài đăng trực tiếp
            post.Address = updatedPost.Address;
            post.Price = updatedPost.Price;
            post.Description = updatedPost.Description;
            post.Area = updatedPost.Area;
            post.UpdationDate = DateTime.Now;

            var result = await _postService.UpdatePostAsync(id, post);

            if (!result)
            {
                return BadRequest(new { success = false, message = "Cập nhật thất bại." });
            }

            return Ok(new { success = true, message = "Cập nhật thành công." });
        }

    }
}
