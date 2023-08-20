using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.DangKyHocRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;

namespace QuanLyTrungTam_API.Service.Interface
{
    public interface IDangKyHocService
    {
        public PageResult<DangKyHocDTO> GetAllDangKyHoc(Pagination pagination);
        public ResponseData<DangKyHocDTO> GetDangKyHocByID(int dangKyHocID);
        public ResponseData<DangKyHocDTO> CreateDangKyHoc(CreateDangKyHocRequest request);
        public ResponseData<DangKyHocDTO> UpdateDangKyHoc(int dangKyHocID, UpdateDangKyHocRequest request);
        public ResponseData<DangKyHocDTO> RemoveDangKyHoc(int dangKyHocID);
    }
}
