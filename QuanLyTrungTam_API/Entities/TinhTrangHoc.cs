﻿namespace QuanLyTrungTam_API.Entities
{
    public class TinhTrangHoc
    {
        public string TenTinhTrang { get; set; } = string.Empty;

        public IEnumerable<DangKyHoc>? ListDangKyHoc { get; set; }
    }
}
