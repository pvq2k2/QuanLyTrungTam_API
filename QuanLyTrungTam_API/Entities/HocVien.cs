namespace QuanLyTrungTam_API.Entities
{
    public class HocVien : BaseEntity
    {
        public string HinhAnh { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TinhThanh { get; set; } = string.Empty;
        public string QuanHuyen { get; set; } = string.Empty;
        public string PhuongXa { get; set; } = string.Empty;
        public string SoNha { get; set; } = string.Empty;

        public IEnumerable<DangKyHoc>? ListDangKyHoc { get; set; }
    }
}
