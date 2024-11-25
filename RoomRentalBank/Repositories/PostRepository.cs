using Microsoft.EntityFrameworkCore;
using RoomRentalBank.Models;
using RoomRentalBank.Interfaces;
using RoomRentalBank.ViewModels;
using RoomRentalBank.Data;

namespace RoomRentalBank.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddPostAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = await GetPostByIdAsync(postId);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post?> GetPostByIdAsync(int postId)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.PostId == postId);
        }

        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId)
        {
            return await _context.Posts
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task UpdatePostAsync(Post post, PostUpdateViewModel viewModel)
        {
            // Chỉ cập nhật các thuộc tính được cho phép trong ViewModel
            post.Address = viewModel.Address;
            post.Description = viewModel.Description;
            post.Price = viewModel.Price;
            post.Status = viewModel.Status;
            post.UpdationDate = DateTime.UtcNow;
            post.Area = viewModel.Area;

            if (viewModel.Features != null)
            {
                post.Feature.Wifi = viewModel.Features.Wifi;
                post.Feature.ParkingSpace = viewModel.Features.ParkingSpace;
                post.Feature.AirConditioner = viewModel.Features.AirConditioner;
                post.Feature.Bathroom = viewModel.Features.Bathroom;
                post.Feature.Kitchen = viewModel.Features.Kitchen;
                post.Feature.WashingMachine = viewModel.Features.WashingMachine;
                post.Feature.Television = viewModel.Features.TV;
                post.Feature.Bed = viewModel.Features.Bed;
                post.Feature.WaterHeater = viewModel.Features.WaterHeater;
            }

            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
