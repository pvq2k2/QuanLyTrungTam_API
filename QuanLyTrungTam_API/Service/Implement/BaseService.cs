using QuanLyTrungTam_API.DBContext;
using QuanLyTrungTam_API.Handle.Converter;

namespace QuanLyTrungTam_API.Service.Implement
{
    public class BaseService
    {
        public readonly AppDbContext dbContext;
        public readonly BaiVietConverter baiVietConverter;
        public readonly ChuDeConverter chuDeConverter;
        public readonly DangKyHocConverter dangKyHocConverter;
        public readonly HocVienConverter hocVienConverter;
        public readonly KhoaHocConverter khoaHocConverter;
        public readonly LoaiBaiVietConverter loaiBaiVietConverter;
        public readonly LoaiKhoaHocConverter loaiKhoaHocConverter;
        public readonly QuyenHanConverter quyenHanConverter;
        public readonly TaiKhoanConverter taiKhoanConverter;
        public readonly TinhTrangHocConverter tinhTrangHocConverter;

        public BaseService()
        {
            dbContext = new AppDbContext();
            baiVietConverter = new BaiVietConverter();
            chuDeConverter = new ChuDeConverter();
            dangKyHocConverter = new DangKyHocConverter();
            hocVienConverter = new HocVienConverter();
            khoaHocConverter = new KhoaHocConverter();
            loaiBaiVietConverter = new LoaiBaiVietConverter();
            loaiKhoaHocConverter = new LoaiKhoaHocConverter();
            quyenHanConverter = new QuyenHanConverter();
            taiKhoanConverter = new TaiKhoanConverter();
            tinhTrangHocConverter = new TinhTrangHocConverter();
        }
    }
}
