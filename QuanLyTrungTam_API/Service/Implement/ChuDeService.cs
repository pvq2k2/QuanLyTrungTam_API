using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.ChuDeRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Service.Implement
{
    public class ChuDeService : BaseService, IChuDeService
    {
        public PageResult<ChuDeDTO> GetAllChuDe(Pagination pagination)
        {
            var query = dbContext.ChuDe.OrderByDescending(x => x.ID).AsQueryable();

            var result = PageResult<ChuDe>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<ChuDeDTO>(pagination, chuDeConverter.ListEntityChuDeToDTO(result.ToList()));
        }

        public ResponseData<ChuDeDTO> GetChuDeByID(int chuDeID)
        {
            var response = new ResponseData<ChuDeDTO>();
            var chuDe = dbContext.ChuDe.FirstOrDefault(x => x.ID == chuDeID);
            if (chuDe == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Chủ đề có ID '{chuDeID}' không tồn tại !";
                return response;
            }
            response.Status = StatusCodes.Status200OK;
            response.Message = "Thành công !";
            response.Data = chuDeConverter.EntityChuDeToDTO(chuDe);
            return response;
        }

        public ResponseData<ChuDeDTO> CreateChuDe(CreateChuDeRequest request)
        {
            var response = new ResponseData<ChuDeDTO>();
            if (!dbContext.LoaiBaiViet.Any(x => x.ID == request.LoaiBaiVietID))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Loại bài viết có ID '{request.LoaiBaiVietID}' không tồn tại !";
                return response;
            }
            ChuDe chuDe = chuDeConverter.CreateChuDe(request);
            dbContext.ChuDe.Add(chuDe);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Thêm chủ đề thành công !";
            response.Data = chuDeConverter.EntityChuDeToDTO(chuDe);
            return response;
        }

        public ResponseData<ChuDeDTO> UpdateChuDe(int chuDeID, UpdateChuDeRequest request)
        {
            var response = new ResponseData<ChuDeDTO>();
            var chuDe = dbContext.ChuDe.FirstOrDefault(x => x.ID == chuDeID);
            if (chuDe == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Chủ đề có ID '{chuDeID}' không tồn tại !";
                return response;
            }
            if (!dbContext.LoaiBaiViet.Any(x => x.ID == request.LoaiBaiVietID))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Loại bài viết có ID '{request.LoaiBaiVietID}' không tồn tại !";
                return response;
            }
            ChuDe chuDeUpdate = chuDeConverter.UpdateChuDe(chuDe, request);
            dbContext.ChuDe.Add(chuDeUpdate);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Cập nhật chủ đề thành công !";
            response.Data = chuDeConverter.EntityChuDeToDTO(chuDeUpdate);
            return response;
        }

        public ResponseData<ChuDeDTO> RemoveChuDe(int chuDeID)
        {
            var response = new ResponseData<ChuDeDTO>();
            var chuDe = dbContext.ChuDe.FirstOrDefault(x => x.ID == chuDeID);
            if (chuDe == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Chủ đề có ID '{chuDeID}' không tồn tại !";
                return response;
            }
            dbContext.ChuDe.Remove(chuDe);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Xóa chủ đề thành công !";
            response.Data = chuDeConverter.EntityChuDeToDTO(chuDe);
            return response;
        }
    }
}
