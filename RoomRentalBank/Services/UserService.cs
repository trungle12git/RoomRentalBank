using RoomRentalBank.Models;
using RoomRentalBank.Interfaces;

namespace RoomRentalBank.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //Dang nhap
        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            return await _userRepository.AuthenticateAsync(username, password);
        }

        //Dang ky
        public async Task<string?> RegisterAsync(User user)
        {
            if (await _userRepository.IsUsernameExistAsync(user.Username)) return "Username da ton tai";
            await _userRepository.RegisterAsync(user);

            return "Dang ky thanh cong";
        }

        //Quan ly tai khoan
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetUserByNameAsync(username);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(user.UserId);
            if (existingUser == null) return false;

            existingUser.Username = user.Username;
            existingUser.PhoneNumber = user.PhoneNumber;

            await _userRepository.UpdateUserAsync(existingUser);                        
            return true;
        }

        public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null || user.Password != oldPassword) return false;

            await _userRepository.ChangePasswordAsync(userId, newPassword);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            if (await _userRepository.IsUserExistAsync(userId)) return false;
            
            await _userRepository.DeleteUserAsync(userId);
            return true;
        }
    }
}
