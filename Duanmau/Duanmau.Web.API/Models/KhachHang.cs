﻿namespace Duanmau.Web.API.Models
{
    public class KhachHang
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Pass { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int Status { get; set; }
        public string? ResetPassCode { get; set; }
    }

}
