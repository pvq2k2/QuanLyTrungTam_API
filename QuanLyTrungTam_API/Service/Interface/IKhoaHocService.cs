using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.KhoaHocRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;

namespace QuanLyTrungTam_API.Service.Interface
{
    public interface IKhoaHocService
    {
        public PageResult<KhoaHocDTO> GetAllKhoaHoc(Pagination pagination);
        public PageResult<KhoaHocDTO> GetKhoaHocByName(string name, Pagination pagination);
        public ResponseData<KhoaHocDTO> GetKhoaHocByID(int khoaHocID);
        public ResponseData<KhoaHocDTO> CreateKhoaHoc(CreateKhoaHocRequest request);
        public ResponseData<KhoaHocDTO> UpdateKhoaHoc(int khoaHocID, UpdateKhoaHocRequest request);
        public ResponseData<KhoaHocDTO> RemoveKhoaHoc(int khoaHocID);
    }
}
