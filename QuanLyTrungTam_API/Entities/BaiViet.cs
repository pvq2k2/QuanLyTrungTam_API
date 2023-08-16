namespace QuanLyTrungTam_API.Entities
{
    public class BaiViet : BaseEntity
    {
        public string TenBaiViet { get; set; } = string.Empty;
        public DateTime ThoiGianTao { get; set; } = DateTime.Now;
        public string TenTacGia { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;
        public string NoiDungNgan { get; set; } = string.Empty;
        public string HinhAnh { get; set; } = string.Empty;

        public int ChuDeID { get; set; }
        public int TaiKhoanID { get; set; }
        public ChuDe? ChuDe { get; set; }
        public TaiKhoan? TaiKhoan { get; set; }
    }
}
