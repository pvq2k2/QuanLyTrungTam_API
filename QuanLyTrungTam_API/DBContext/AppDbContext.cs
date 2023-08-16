﻿using Microsoft.EntityFrameworkCore;
using QuanLyTrungTam_API.Entities;

namespace QuanLyTrungTam_API.DBContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<BaiViet> BaiViet { get; set; }
        public DbSet<ChuDe> ChuDe { get; set; }
        public DbSet<DangKyHoc> DangKyHoc { get; set; }
        public DbSet<HocVien> HocVien { get; set; }
        public DbSet<KhoaHoc> KhoaHoc { get; set; }
        public DbSet<LoaiBaiViet> LoaiBaiViet { get; set; }
        public DbSet<LoaiKhoaHoc> LoaiKhoaHoc { get; set; }
        public DbSet<QuyenHan> QuyenHan { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
        public DbSet<TinhTrangHoc> TinhTrangHoc { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.MyConnectString());
        }
    }
}
