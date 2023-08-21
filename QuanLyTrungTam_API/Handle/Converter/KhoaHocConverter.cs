using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.KhoaHocRequest;

namespace QuanLyTrungTam_API.Handle.Converter
{
    public class KhoaHocConverter
    {
        public KhoaHocDTO EntityKhoaHocToDTO(KhoaHoc khoaHoc)
        {
            return new KhoaHocDTO()
            {
                TenKhoaHoc = khoaHoc.TenKhoaHoc,
                ThoiGianHoc = khoaHoc.ThoiGianHoc,
                GioiThieu = khoaHoc.GioiThieu,
                NoiDung = khoaHoc.NoiDung,
                HocPhi = khoaHoc.HocPhi,
                SoHocVien = khoaHoc.SoHocVien,
                SoLuongMon = khoaHoc.SoLuongMon,
                HinhAnh = khoaHoc.HinhAnh
            };
        }

        public List<KhoaHocDTO> ListEntityKhoaHocToDTO(List<KhoaHoc> listKhoaHoc)
        {
            var listKhoaHocDTO = new List<KhoaHocDTO>();
            foreach (var khoaHoc in listKhoaHoc)
            {
                listKhoaHocDTO.Add(EntityKhoaHocToDTO(khoaHoc));
            }

            return listKhoaHocDTO;
        }

        public KhoaHoc CreateKhoaHoc(CreateKhoaHocRequest request)
        {
            return new KhoaHoc
            {
                TenKhoaHoc = request.TenKhoaHoc,
                ThoiGianHoc = request.ThoiGianHoc,
                GioiThieu = request.GioiThieu,
                NoiDung = request.NoiDung,
                HocPhi = request.HocPhi,
                SoLuongMon = request.SoLuongMon,
                HinhAnh = request.HinhAnh,
                LoaiKhoaHocID = request.LoaiKhoaHocID
            };
        }

        public KhoaHoc UpdateKhoaHoc(KhoaHoc khoaHoc, UpdateKhoaHocRequest request)
        {
            khoaHoc.TenKhoaHoc = request.TenKhoaHoc;
            khoaHoc.ThoiGianHoc = request.ThoiGianHoc;
            khoaHoc.GioiThieu = request.GioiThieu;
            khoaHoc.NoiDung = request.NoiDung;
            khoaHoc.HocPhi = request.HocPhi;
            khoaHoc.SoLuongMon = request.SoLuongMon;
            khoaHoc.HinhAnh = request.HinhAnh;
            khoaHoc.LoaiKhoaHocID = request.LoaiKhoaHocID;

            return khoaHoc;
        }
    }
}
