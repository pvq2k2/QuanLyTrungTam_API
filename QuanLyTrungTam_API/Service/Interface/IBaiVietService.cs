using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.BaiVietRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;

namespace QuanLyTrungTam_API.Service.Interface
{
    public interface IBaiVietService
    {
        public PageResult<BaiVietDTO> GetAllBaiViet(Pagination pagination);
        public PageResult<BaiVietDTO> GetBaiVietByTenBaiViet(string tenBaiViet, Pagination pagination);
        public ResponseData<BaiVietDTO> GetBaiVietByID(int baiVietID);
        public ResponseData<BaiVietDTO> CreateBaiViet(CreateBaiVietRequest request);
        public ResponseData<BaiVietDTO> UpdateBaiViet(int baiVietID, UpdateBaiVietRequest request);
        public ResponseData<BaiVietDTO> RemoveBaiViet(int baiVietID);
    }
}
