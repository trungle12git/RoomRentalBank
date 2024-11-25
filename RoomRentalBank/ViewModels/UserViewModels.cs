
namespace RoomRentalBank.ViewModels
{
    public class UserLoginViewModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public class UserRegisterViewModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
    }

    public class UserUpdateViewModel
    {
        public required string Username { get; set; }
        public required string PhoneNumber { get; set; }
    }

    public class ChangePasswordViewModel
    {
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
    }
}
