using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.BaiVietRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Service.Implement
{
    public class BaiVietService : BaseService, IBaiVietService
    {
        public PageResult<BaiVietDTO> GetAllBaiViet(Pagination pagination)
        {
            var query = dbContext.BaiViet.OrderByDescending(x => x.ID).AsQueryable();

            var result = PageResult<BaiViet>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<BaiVietDTO>(pagination, baiVietConverter.ListEntityBaiVietToDTO(result.ToList()));
        }

        public PageResult<BaiVietDTO> GetBaiVietByTenBaiViet(string tenBaiViet, Pagination pagination)
        {
            var query = dbContext.BaiViet.OrderByDescending(x => x.ID).AsQueryable();

            if (!string.IsNullOrEmpty(tenBaiViet))
            {
                query = query.Where(x => x.TenBaiViet.ToLower().Contains(tenBaiViet.ToLower()));
            }

            var result = PageResult<BaiViet>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<BaiVietDTO>(pagination, baiVietConverter.ListEntityBaiVietToDTO(result.ToList()));
        }

        public ResponseData<BaiVietDTO> GetBaiVietByID(int baiVietID)
        {
            var response = new ResponseData<BaiVietDTO>();
            var baiViet = dbContext.BaiViet.FirstOrDefault(x => x.ID == baiVietID);
            if (baiViet == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Bài viết có ID '{baiVietID}' không tồn tại !";
                return response;
            }
            response.Status = StatusCodes.Status200OK;
            response.Message = "Thành công !";
            response.Data = baiVietConverter.EntityBaiVietToDTO(baiViet);
            return response;
        }

        public ResponseData<BaiVietDTO> CreateBaiViet(CreateBaiVietRequest request)
        {
            var response = new ResponseData<BaiVietDTO>();
            if (!dbContext.ChuDe.Any(x => x.ID == request.ChuDeID))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Chủ đề có ID '{request.ChuDeID}' không tồn tại !";
                return response;
            }
            if (!dbContext.TaiKhoan.Any(x => x.ID == request.TaiKhoanID))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Tài khoản có ID '{request.TaiKhoanID}' không tồn tại !";
                return response;
            }
            BaiViet baiViet = baiVietConverter.CreateBaiViet(request);
            dbContext.BaiViet.Add(baiViet);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Thêm bài viết thành công !";
            return response;
        }

        public ResponseData<BaiVietDTO> UpdateBaiViet(int baiVietID, UpdateBaiVietRequest request)
        {
            var response = new ResponseData<BaiVietDTO>();
            var baiViet = dbContext.BaiViet.FirstOrDefault(x => x.ID == baiVietID);
            if (baiViet == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Bài viết có ID '{baiVietID}' không tồn tại !";
                return response;
            }
            if (!dbContext.ChuDe.Any(x => x.ID == request.ChuDeID))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Chủ đề có '{request.ChuDeID}' không tồn tại !";
                return response;
            }
            BaiViet baiVietUpdate = baiVietConverter.UpdateBaiViet(baiViet, request);
            dbContext.BaiViet.Update(baiVietUpdate);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Cập nhật bài viết thành công !";
            response.Data = baiVietConverter.EntityBaiVietToDTO(baiVietUpdate);
            return response;
        }

        public ResponseData<BaiVietDTO> RemoveBaiViet(int baiVietID)
        {
            var response = new ResponseData<BaiVietDTO>();
            var baiViet = dbContext.BaiViet.FirstOrDefault(x => x.ID == baiVietID);
            if (baiViet == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Bài viết có ID '{baiVietID}' không tồn tại !";
                return response;
            }
            dbContext.BaiViet.Remove(baiViet);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Cập nhật bài viết thành công !";
            response.Data = baiVietConverter.EntityBaiVietToDTO(baiViet);
            return response;
        }
    }
}
