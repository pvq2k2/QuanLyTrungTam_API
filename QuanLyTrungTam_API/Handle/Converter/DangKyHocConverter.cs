using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.DangKyHocRequest;

namespace QuanLyTrungTam_API.Handle.Converter
{
    public class DangKyHocConverter
    {
        public DangKyHocDTO EntityDangKyHocToDTO(DangKyHoc dangKyHoc)
        {
            return new DangKyHocDTO
            {
                NgayDangKy = dangKyHoc.NgayDangKy,
                NgayBatDau = dangKyHoc.NgayBatDau,
                NgayKetThuc = dangKyHoc.NgayKetThuc
            };
        }

        public DangKyHoc CreateDangKyHoc(CreateDangKyHocRequest request)
        {
            return new DangKyHoc
            {
                KhoaHocID = request.KhoaHocID,
                HocVienID = request.HocVienID,
                TinhTrangHocID = request.TinhTrangHocID,
                TaiKhoanID = request.TaiKhoanID
            };
        }

        public DangKyHoc UpdateDangKyHoc(DangKyHoc dangKyHoc, UpdateDangKyHocRequest request)
        {
            dangKyHoc.KhoaHocID = request.KhoaHocID;
            dangKyHoc.HocVienID = request.HocVienID;
            dangKyHoc.TinhTrangHocID = request.TinhTrangHocID;
            dangKyHoc.TaiKhoanID = request.TaiKhoanID;

            return dangKyHoc;
        }
    }
}
