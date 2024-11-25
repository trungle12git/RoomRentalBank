namespace RoomRentalBank.ViewModels
{
    public class PostUpdateViewModel
    {
        public string? Address { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? Status { get; set; }
        public decimal Area { get; set; }
        public PostFeaturesViewModel? Features { get; set; } // Tiện ích bài đăng
    }

    public class PostFeaturesViewModel
    {
        public bool Wifi { get; set; }
        public bool ParkingSpace { get; set; }
        public bool AirConditioner { get; set; }
        public bool Bathroom { get; set; }
        public bool Kitchen { get; set; }
        public bool WashingMachine { get; set; }
        public bool TV { get; set; }
        public bool Bed { get; set; }
        public bool WaterHeater { get; set; }
    }
}
