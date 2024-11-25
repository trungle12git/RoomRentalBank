using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomRentalBank.Models
{
    [Table("Post_Features")]
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }
        public int PostId { get; set; }
        public bool Wifi { get; set; }
        public bool ParkingSpace { get; set; }
        public bool AirConditioner { get; set; }
        public bool Bathroom { get; set; }
        public bool Kitchen { get; set; }
        public bool WashingMachine { get; set; }
        public bool Television { get; set; }
        public bool Bed {  get; set; }
        public bool WaterHeater { get; set; }

        public required Post Post { get; set; }
    }
}
