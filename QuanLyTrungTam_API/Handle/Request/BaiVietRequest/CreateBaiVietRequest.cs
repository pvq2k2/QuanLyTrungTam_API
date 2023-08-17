namespace QuanLyTrungTam_API.Handle.Request.BaiVietRequest
{
    public class CreateBaiVietRequest
    {
        public string TenBaiViet { get; set; } = string.Empty;
        public string TenTacGia { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;
        public string NoiDungNgan { get; set; } = string.Empty;
        public string HinhAnh { get; set; } = string.Empty;

        public int ChuDeID { get; set; }
        public int TaiKhoanID { get; set; }
    }
}
