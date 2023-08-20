using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.ChuDeRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;

namespace QuanLyTrungTam_API.Service.Interface
{
    public interface IChuDeService
    {
        public PageResult<ChuDeDTO> GetAllChuDe(Pagination pagination);
        public ResponseData<ChuDeDTO> GetChuDeByID(int chuDeID);
        public ResponseData<ChuDeDTO> CreateChuDe(CreateChuDeRequest request);
        public ResponseData<ChuDeDTO> UpdateChuDe(int chuDeID, UpdateChuDeRequest request);
        public ResponseData<ChuDeDTO> RemoveChuDe(int chuDeID);
    }
}
