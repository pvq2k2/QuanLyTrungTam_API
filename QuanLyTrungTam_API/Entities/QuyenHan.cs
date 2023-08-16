namespace QuanLyTrungTam_API.Entities
{
    public class QuyenHan : BaseEntity
    {
        public string TenQuyenHan { get; set; } = string.Empty;

        public IEnumerable<TaiKhoan>? ListTaiKhoan { get; set; }
    }
}
