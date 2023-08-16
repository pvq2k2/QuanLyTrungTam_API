namespace QuanLyTrungTam_API.Entities
{
    public class LoaiBaiViet : BaseEntity
    {
        public string TenLoai { get; set; } = string.Empty;

        public IEnumerable<ChuDe>? ListChuDe { get; set; }
    }
}
