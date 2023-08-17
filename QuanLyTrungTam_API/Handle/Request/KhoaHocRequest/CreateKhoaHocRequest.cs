namespace QuanLyTrungTam_API.Handle.Request.KhoaHocRequest
{
    public class CreateKhoaHocRequest
    {
        public string TenKhoaHoc { get; set; } = string.Empty;
        public int ThoiGianHoc { get; set; }
        public string GioiThieu { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;
        public int HocPhi { get; set; }
        public int SoLuongMon { get; set; }
        public string HinhAnh { get; set; } = string.Empty;

        public int LoaiKhoaHocID { get; set; }
    }
}
