namespace QuanLyTrungTam_API.Handle.Request.DangKyHocRequest
{
    public class CreateDangKyHocRequest
    {
        public int KhoaHocID { get; set; }
        public int HocVienID { get; set; }
        public int TinhTrangHocID { get; set; }
        public int TaiKhoanID { get; set; }
    }
}
