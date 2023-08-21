using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.LoaiBaiVietRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;

namespace QuanLyTrungTam_API.Service.Interface
{
    public interface ILoaiBaiVietService
    {
        public PageResult<LoaiBaiVietDTO> GetAllLoaiBaiViet(Pagination pagination);
        public ResponseData<LoaiBaiVietDTO> GetLoaiBaiVietByID(int loaiBaiVietID);
        public ResponseData<LoaiBaiVietDTO> CreateLoaiBaiViet(CreateLoaiBaiVietRequest request);
        public ResponseData<LoaiBaiVietDTO> UpdateLoaiBaiViet(int loaiBaiVietID, UpdateLoaiBaiVietRequest request);
        public ResponseData<LoaiBaiVietDTO> RemoveLoaiBaiViet(int loaiBaiVietID);
    }
}
