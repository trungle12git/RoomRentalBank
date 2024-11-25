using RoomRentalBank.Models;
using RoomRentalBank.ViewModels;

namespace RoomRentalBank.Interfaces
{
    public interface IPostRepository
    {
        // Lấy tất cả bài đăng
        Task<IEnumerable<Post>> GetAllPostsAsync();

        // Lấy bài đăng theo ID
        Task<Post?> GetPostByIdAsync(int postId);

        // Lấy danh sách bài đăng theo UserId
        Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId);

        // Thêm bài đăng mới
        Task AddPostAsync(Post post);

        // Cập nhật bài đăng (sử dụng ViewModel)
        Task UpdatePostAsync(Post post, PostUpdateViewModel viewModel);

        // Xóa bài đăng
        Task DeletePostAsync(int postId);
    }
}
