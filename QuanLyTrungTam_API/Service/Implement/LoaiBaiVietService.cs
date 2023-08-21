using Azure.Core;
using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.LoaiBaiVietRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Service.Implement
{
    public class LoaiBaiVietService : BaseService, ILoaiBaiVietService
    {
        public PageResult<LoaiBaiVietDTO> GetAllLoaiBaiViet(Pagination pagination)
        {
            var query = dbContext.LoaiBaiViet.OrderByDescending(x => x.ID).AsQueryable();

            var result = PageResult<LoaiBaiViet>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<LoaiBaiVietDTO>(pagination, loaiBaiVietConverter.ListEntityLoaiBaiVietToDTO(result.ToList()));
        }

        public ResponseData<LoaiBaiVietDTO> GetLoaiBaiVietByID(int loaiBaiVietID)
        {
            var response = new ResponseData<LoaiBaiVietDTO>();
            var loaiBaiViet = dbContext.LoaiBaiViet.FirstOrDefault(x => x.ID == loaiBaiVietID);
            if (loaiBaiViet == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Loại bài viết có ID '{loaiBaiVietID}' không tồn tại !";
                return response;
            }
            response.Status = StatusCodes.Status200OK;
            response.Message = $"Thành công !";
            response.Data = loaiBaiVietConverter.EntityLoaiBaiVietToDTO(loaiBaiViet);
            return response;
        }

        public ResponseData<LoaiBaiVietDTO> CreateLoaiBaiViet(CreateLoaiBaiVietRequest request)
        {
            var response = new ResponseData<LoaiBaiVietDTO>();
            LoaiBaiViet loaiBaiViet = loaiBaiVietConverter.CreateLoaiBaiViet(request);
            dbContext.LoaiBaiViet.Add(loaiBaiViet);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = $"Thêm loại bài viết thành công !";
            response.Data = loaiBaiVietConverter.EntityLoaiBaiVietToDTO(loaiBaiViet);
            return response;
        }

        public ResponseData<LoaiBaiVietDTO> UpdateLoaiBaiViet(int loaiBaiVietID, UpdateLoaiBaiVietRequest request)
        {
            var response = new ResponseData<LoaiBaiVietDTO>();
            var loaiBaiViet = dbContext.LoaiBaiViet.FirstOrDefault(x => x.ID == loaiBaiVietID);
            if (loaiBaiViet == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Loại bài viết có ID '{loaiBaiVietID}' không tồn tại !";
                return response;
            }
            LoaiBaiViet loaiBaiVietUpdate = loaiBaiVietConverter.UpdateLoaiBaiViet(loaiBaiViet, request);
            dbContext.LoaiBaiViet.Add(loaiBaiViet);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = $"Thêm loại bài viết thành công !";
            response.Data = loaiBaiVietConverter.EntityLoaiBaiVietToDTO(loaiBaiViet);
            return response;
        }

        public ResponseData<LoaiBaiVietDTO> RemoveLoaiBaiViet(int loaiBaiVietID)
        {
            var response = new ResponseData<LoaiBaiVietDTO>();
            var loaiBaiViet = dbContext.LoaiBaiViet.FirstOrDefault(x => x.ID == loaiBaiVietID);
            if (loaiBaiViet == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Loại bài viết có ID '{loaiBaiVietID}' không tồn tại !";
                return response;
            }
            dbContext.LoaiBaiViet.Remove(loaiBaiViet);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = $"Xóa loại bài viết thành công !";
            response.Data = loaiBaiVietConverter.EntityLoaiBaiVietToDTO(loaiBaiViet);
            return response;
        }
    }
}
