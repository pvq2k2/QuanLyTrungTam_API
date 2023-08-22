namespace QuanLyTrungTam_API.Entities
{
    public class TaiKhoan : BaseEntity
    {
        public string TenNguoiDung { get; set; } = string.Empty;
        public string TenTaiKhoan { get; set; } = string.Empty;
        public string MatKhau { get; set; } = string.Empty;
        public int QuyenHanID { get; set; }

        public QuyenHan? QuyenHan { get; set; }
        public IEnumerable<DangKyHoc>? ListDangKyHoc { get; set; }
        public IEnumerable<BaiViet>? ListBaiViet { get; set; }
    }
}
