using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.LoaiKhoaHocRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;

namespace QuanLyTrungTam_API.Service.Interface
{
    public interface ILoaiKhoaHocService
    {
        public PageResult<LoaiKhoaHocDTO> GetAllLoaiKhoaHoc(Pagination pagination);
        public ResponseData<LoaiKhoaHocDTO> GetLoaiKhoaHocByID(int loaiKhoaHocID);
        public ResponseData<LoaiKhoaHocDTO> CreateLoaiKhoaHoc(CreateLoaiKhoaHocRequest request);
        public ResponseData<LoaiKhoaHocDTO> UpadateLoaiKhoaHoc(int loaiKhoaHocID, UpdateLoaiKhoaHocRequest request);
        public ResponseData<LoaiKhoaHocDTO> RemoveLoaiKhoaHoc(int loaiKhoaHocID);
    }
}
