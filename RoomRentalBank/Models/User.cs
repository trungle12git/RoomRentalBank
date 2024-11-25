using System.Collections.Generic;

namespace RoomRentalBank.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }

        public ICollection<Post>? Posts { get; set; }
    }
}
