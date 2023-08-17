namespace QuanLyTrungTam_API.Handle.Request.ChuDeRequest
{
    public class CreateChuDeRequest
    {
        public string TenChuDe { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;

        public int LoaiBaiVietID { get; set; }
    }
}
