using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomRentalBank.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("username")]
        public required string Username { get; set; }

        [Column("password")]
        public required string Password { get; set; }

        [Column("phone_number")]
        public required string PhoneNumber { get; set; }

        public ICollection<Post>? Posts { get; set; }
    }
}
