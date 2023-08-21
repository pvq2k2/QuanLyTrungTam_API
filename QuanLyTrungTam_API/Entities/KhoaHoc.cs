namespace QuanLyTrungTam_API.Entities
{
    public class KhoaHoc : BaseEntity
    {
        public string TenKhoaHoc { get; set; } = string.Empty;
        public int ThoiGianHoc { get; set; }
        public string GioiThieu { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;
        public int HocPhi { get; set; }
        public int SoHocVien { get; set; } = 0;
        public int SoLuongMon { get; set; }
        public string HinhAnh { get; set; } = string.Empty;

        public int LoaiKhoaHocID { get; set; }
        public LoaiKhoaHoc? LoaiKhoaHoc { get; set; }
        public IEnumerable<DangKyHoc> ListDangKyHoc { get; set; } = new List<DangKyHoc>();
    }
}
