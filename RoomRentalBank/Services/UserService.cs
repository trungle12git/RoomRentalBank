using RoomRentalBank.Models;
using RoomRentalBank.Interfaces;
using RoomRentalBank.ViewModels;

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
        public async Task<bool> RegisterAsync(UserRegisterViewModel registerModel)
        {
            var user = new User
            {
                Username = registerModel.Username,
                Password = registerModel.Password,
                PhoneNumber = registerModel.PhoneNumber
            };
            return await _userRepository.RegisterAsync(user);
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

        public async Task<bool> UpdateUserAsync(int userId, UserUpdateViewModel updateModel)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return false;

            user.Username = updateModel.Username;
            
            user.PhoneNumber = updateModel.PhoneNumber;

            return await _userRepository.UpdateUserAsync(user);
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
            return await _userRepository.DeleteUserAsync(userId);
        }
    }
}
