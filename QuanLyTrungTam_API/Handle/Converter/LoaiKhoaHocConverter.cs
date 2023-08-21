using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.LoaiKhoaHocRequest;

namespace QuanLyTrungTam_API.Handle.Converter
{
    public class LoaiKhoaHocConverter
    {
        public LoaiKhoaHocDTO EntityLoaiKhoaHocToDTO(LoaiKhoaHoc loaiKhoaHoc)
        {
            return new LoaiKhoaHocDTO
            {
                TenLoai = loaiKhoaHoc.TenLoai,
            };
        }

        public List<LoaiKhoaHocDTO> ListEntityLoaiKhoaHocToDTO(List<LoaiKhoaHoc> listLoaiKhoaHoc)
        {
            var listLoaiKhoaHocDTO = new List<LoaiKhoaHocDTO>();
            foreach (var loaiKhoaHoc in listLoaiKhoaHoc)
            {
                listLoaiKhoaHocDTO.Add(EntityLoaiKhoaHocToDTO(loaiKhoaHoc));
            }

            return listLoaiKhoaHocDTO;
        }

        public LoaiKhoaHoc CreateLoaiKhoaHoc(CreateLoaiKhoaHocRequest request)
        {
            return new LoaiKhoaHoc
            {
                TenLoai = request.TenLoai,
            };
        }

        public LoaiKhoaHoc UpdateLoaiKhoaHoc(LoaiKhoaHoc loaiKhoaHoc, UpdateLoaiKhoaHocRequest request)
        {
            loaiKhoaHoc.TenLoai = request.TenLoai;

            return loaiKhoaHoc;
        }
    }
}
