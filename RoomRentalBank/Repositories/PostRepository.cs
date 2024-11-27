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
            return await _context.Posts
                      .Include(p => p.User)
                      .ToListAsync();
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

        public async Task UpdatePostAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
