namespace QuanLyTrungTam_API.Entities
{
    public class DangKyHoc : BaseEntity
    {
        public int KhoaHocID { get; set; }
        public int HocVienID { get; set; }
        public DateTime NgayDangKy { get; set; } = DateTime.Now;
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int TinhTrangHocID { get; set; }
        public int TaiKhoanID { get; set; }

        public KhoaHoc? KhoaHoc { get; set; }
        public HocVien? HocVien { get; set; }
        public TinhTrangHoc? TinhTrangHoc { get; set; }
        public TaiKhoan? TaiKhoan { get; set; }
    }
}
