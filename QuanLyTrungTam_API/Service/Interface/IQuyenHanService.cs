using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.QuyenHanRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;

namespace QuanLyTrungTam_API.Service.Interface
{
    public interface IQuyenHanService
    {
        public PageResult<QuyenHanDTO> GetAllQuyenHan(Pagination pagination);
        public ResponseData<QuyenHanDTO> GetQuyenHanByID(int quyenHanID);
        public ResponseData<QuyenHanDTO> CreateQuyenHan(CreateQuyenHanRequest request);
        public ResponseData<QuyenHanDTO> UpdateQuyenHan(int quyenHanID, UpdateQuyenHanRequest request);
        public ResponseData<QuyenHanDTO> RemoveQuyenHan(int quyenHanID);
    }
}
