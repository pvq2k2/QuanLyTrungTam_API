using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.BaiVietRequest;

namespace QuanLyTrungTam_API.Handle.Converter
{
    public class BaiVietConverter
    {
        public BaiVietDTO EntityBaiVietToDTO(BaiViet baiViet)
        {
            return new BaiVietDTO
            {
                TenBaiViet = baiViet.TenBaiViet,
                ThoiGianTao = baiViet.ThoiGianTao,
                TenTacGia = baiViet.TenTacGia,
                NoiDung = baiViet.NoiDung,
                NoiDungNgan = baiViet.NoiDungNgan,
                HinhAnh = baiViet.HinhAnh
            };
        }

        public List<BaiVietDTO> ListEntityBaiVietToDTO(List<BaiViet> listBaiViet)
        {
            var listBaiVietDTO = new List<BaiVietDTO>();
            foreach (var baiViet in listBaiViet)
            {
                listBaiVietDTO.Add(EntityBaiVietToDTO(baiViet));
            }

            return listBaiVietDTO;
        }

        public BaiViet CreateBaiViet(CreateBaiVietRequest request)
        {
            return new BaiViet
            {
                TenBaiViet = request.TenBaiViet,
                TenTacGia = request.TenTacGia,
                NoiDung = request.NoiDung,
                NoiDungNgan = request.NoiDungNgan,
                HinhAnh = request.HinhAnh,
                ChuDeID = request.ChuDeID,
                TaiKhoanID = request.TaiKhoanID
            };
        }

        public BaiViet UpdateBaiViet(BaiViet baiViet, UpdateBaiVietRequest request)
        {
            baiViet.TenBaiViet = request.TenBaiViet;
            baiViet.TenTacGia = request.TenTacGia;
            baiViet.NoiDung = request.NoiDung;
            baiViet.NoiDungNgan = request.NoiDungNgan;
            baiViet.HinhAnh = request.HinhAnh;
            baiViet.ChuDeID = request.ChuDeID;

            return baiViet;
        }
    }
}
