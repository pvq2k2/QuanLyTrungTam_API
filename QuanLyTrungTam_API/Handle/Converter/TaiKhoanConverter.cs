using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.TaiKhoanRequest;

namespace QuanLyTrungTam_API.Handle.Converter
{
    public class TaiKhoanConverter
    {
        public TaiKhoanDTO EntityTaiKhoanToDTO(TaiKhoan taiKhoan)
        {
            return new TaiKhoanDTO
            {
                TenNguoiDung = taiKhoan.TenNguoiDung,
                TenTaiKhoan = taiKhoan.TenTaiKhoan
            };
        }

        public List<TaiKhoanDTO> ListEntityTaiKhoanToDTO(List<TaiKhoan> listTaiKhoan)
        {
            var listTaiKhoanDTO = new List<TaiKhoanDTO>();
            foreach (var taiKhoan in listTaiKhoan)
            {
                listTaiKhoanDTO.Add(EntityTaiKhoanToDTO(taiKhoan));
            }

            return listTaiKhoanDTO;
        }

        public TaiKhoan CreateTaiKhoan(CreateTaiKhoanRequest request)
        {
            return new TaiKhoan
            {
                TenNguoiDung = request.TenNguoiDung,
                TenTaiKhoan = request.TenTaiKhoan,
                MatKhau = request.MatKhau,
                QuyenHanID = request.QuyenHanID
            };
        }

        public TaiKhoan UpdateTaiKhoan(TaiKhoan taiKhoan, UpdateTaiKhoanRequest request)
        {
            taiKhoan.TenNguoiDung = request.TenNguoiDung;
            taiKhoan.TenTaiKhoan = request.TenTaiKhoan;
            taiKhoan.QuyenHanID = request.QuyenHanID;

            return taiKhoan;
        }
    }
}
