using RoomRentalBank.Models;

namespace RoomRentalBank.Interfaces
{
    public interface IUserRepository
    {
        //Đăng nhập
        Task<User?> AuthenticateAsync(string username, string password);
        Task<bool> IsUserExistAsync(int userId);

        //Dang ky
        Task<bool> IsUsernameExistAsync(string username);
        Task RegisterAsync(User user);

        //Quan ly tai khoan
        Task<User?> GetUserByIdAsync(int userId);
        Task<User?> GetUserByNameAsync(string username);
        Task UpdateUserAsync(User user);
        Task ChangePasswordAsync(int userId, string newPassword);
        Task DeleteUserAsync(int userId);
    }
}
