﻿namespace QuanLyTrungTam_API.Handle.Request.TaiKhoanRequest
{
    public class UpdateTaiKhoanRequest
    {
        public string TenNguoiDung { get; set; } = string.Empty;
        public string TenTaiKhoan { get; set; } = string.Empty;
        public int QuyenHanID { get; set; }
    }
}
