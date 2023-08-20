using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.TinhTrangHocRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;

namespace QuanLyTrungTam_API.Service.Interface
{
    public interface ITinhTrangHocService
    {
        public PageResult<TinhTrangHocDTO> GetAllTinhTrangHoc(Pagination pagination);
        public ResponseData<TinhTrangHocDTO> GetTinhTrangHocByID(int tinhTrangHocID);
        public ResponseData<TinhTrangHocDTO> CreateTinhTrangHoc(CreateTinhTrangHocRequest request);
        public ResponseData<TinhTrangHocDTO> UpdateTinhTrangHoc(int tinhTrangHocID, UpdateTinhTrangHocRequest request);
        public ResponseData<TinhTrangHocDTO> RemoveTinhTrangHoc(int tinhTrangHocID);
    }
}
