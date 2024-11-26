using RoomRentalBank.Models;
using RoomRentalBank.Interfaces;
using RoomRentalBank.ViewModels;

namespace RoomRentalBank.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        //Lay bai dang theo Id
        public async Task<Post?> GetPostByIdAsync(int postId)
        {
            return await _postRepository.GetPostByIdAsync(postId);
        }

        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId)
        {
            return await _postRepository.GetPostsByUserIdAsync(userId);
        }

        // Thêm bài đăng mới
        public async Task AddPostAsync(Post post)
        {
            await _postRepository.AddPostAsync(post);
        }

        // Cập nhật bài đăng
        public async Task<bool> UpdatePostAsync(int postId, PostUpdateViewModel viewModel)
        {
            var post = await _postRepository.GetPostByIdAsync(postId);
            if (post == null)
                return false;

            await _postRepository.UpdatePostAsync(post, viewModel);
            return true;
        }

        // Xóa bài đăng
        public async Task<bool> DeletePostAsync(int postId)
        {
            var post = await _postRepository.GetPostByIdAsync(postId);
            if (post == null)
                return false;

            await _postRepository.DeletePostAsync(postId);
            return true;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllPostsAsync();
        }
    }
}
