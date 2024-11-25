using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomRentalBank.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }

        public ICollection<Post>? Posts { get; set; }
    }
}
