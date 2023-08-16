namespace QuanLyTrungTam_API.Entities
{
    public class ChuDe : BaseEntity
    {
        public string TenChuDe { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;

        public int LoaiBaiVietID { get; set; }
        public LoaiBaiViet? LoaiBaiViet { get; set; }
        public IEnumerable<BaiViet>? ListBaiViet { get; set; }
    }
}
