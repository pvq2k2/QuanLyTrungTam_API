using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.HocVienRequest;

namespace QuanLyTrungTam_API.Handle.Converter
{
    public class HocVienConverter
    {
        public HocVienDTO EntityHocVienToDTO(HocVien hocVien)
        {
            return new HocVienDTO
            {
                HinhAnh = hocVien.HinhAnh,
                HoTen = hocVien.HoTen,
                NgaySinh = hocVien.NgaySinh,
                SDT = hocVien.SDT,
                Email = hocVien.Email,
                TinhThanh = hocVien.TinhThanh,
                QuanHuyen = hocVien.QuanHuyen,
                PhuongXa = hocVien.PhuongXa,
                SoNha = hocVien.SoNha
            };
        }

        public List<HocVienDTO> ListEntityHocVienToDTO(List<HocVien> listHocVien)
        {
            var listHocVienDTO = new List<HocVienDTO>();
            foreach (var hocVien in listHocVien)
            {
                listHocVienDTO.Add(EntityHocVienToDTO(hocVien));
            }

            return listHocVienDTO;
        }

        public HocVien CreateHocVien(CreateHocVienRequest request)
        {
            return new HocVien
            {
                HinhAnh = request.HinhAnh,
                HoTen = request.HoTen,
                NgaySinh = request.NgaySinh,
                SDT = request.SDT,
                Email = request.Email,
                TinhThanh = request.TinhThanh,
                QuanHuyen = request.QuanHuyen,
                PhuongXa = request.PhuongXa,
                SoNha = request.SoNha
            };
        }

        public HocVien UpdateHocVien(HocVien hocVien, UpdateHocVienRequest request)
        {
            hocVien.HinhAnh = request.HinhAnh;
            hocVien.HoTen = request.HoTen;
            hocVien.NgaySinh = request.NgaySinh;
            hocVien.SDT = request.SDT;
            hocVien.Email = request.Email;
            hocVien.TinhThanh = request.TinhThanh;
            hocVien.QuanHuyen = request.QuanHuyen;
            hocVien.PhuongXa = request.PhuongXa;
            hocVien.SoNha = request.SoNha;

            return hocVien;
        }
    }
}
