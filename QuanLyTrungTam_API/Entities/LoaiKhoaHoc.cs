namespace QuanLyTrungTam_API.Entities
{
    public class LoaiKhoaHoc : BaseEntity
    {
        public string TenLoai { get; set; } = string.Empty;

        public IEnumerable<KhoaHoc>? ListKhoaHoc { get; set; }
    }
}
