using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System;

namespace RoomRentalBank.ViewModels
{
    public class PostCreateViewModel
    {
        public int UserId { get; set; }

        [Required]
        public required string Address { get; set; }

        [Required]
        public required int Price { get; set; }

        public string? Description { get; set; }

        public string? ImageUrls { get; set; } // Có thể sử dụng chuỗi chứa URL, hoặc List<string> nếu cần

        [Required]
        public decimal Area { get; set; }

        public string? Status { get; set; }

        public int EawCharge { get; set; } 

        // Các trường liên quan đến ngày tháng
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        // Thêm các tính năng của bài đăng
        public FeatureViewModel? Features { get; set; }
    }

    public class PostUpdateViewModel
    {
        public string? Address { get; set; }

        public int Price { get; set; }

        public string? Description { get; set; }

        public string? ImageUrls { get; set; }

        public decimal Area { get; set; }

        public string? Status { get; set; }

        public int EawCharge { get; set; } // Trạng thái bài đăng

        public DateTime? UpdatedDate { get; set; } // Thời gian cập nhật (có thể null)

        // Các tính năng của bài đăng
        public FeatureViewModel? Features { get; set; }
    }
}
