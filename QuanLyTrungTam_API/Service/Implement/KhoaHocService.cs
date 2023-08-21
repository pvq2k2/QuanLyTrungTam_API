using Microsoft.EntityFrameworkCore;
using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.KhoaHocRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Service.Implement
{
    public class KhoaHocService : BaseService, IKhoaHocService
    {
        public PageResult<KhoaHocDTO> GetAllKhoaHoc(Pagination pagination)
        {
            var query = dbContext.KhoaHoc.OrderByDescending(x => x.ID).AsQueryable();

            var result = PageResult<KhoaHoc>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<KhoaHocDTO>(pagination, khoaHocConverter.ListEntityKhoaHocToDTO(result.ToList()));
        }

        public PageResult<KhoaHocDTO> GetKhoaHocByName(string name, Pagination pagination)
        {
            var query = dbContext.KhoaHoc.OrderByDescending(x => x.ID).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.TenKhoaHoc.ToLower().Contains(name.ToLower()));
            }

            var result = PageResult<KhoaHoc>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<KhoaHocDTO>(pagination, khoaHocConverter.ListEntityKhoaHocToDTO(result.ToList()));
        }

        public ResponseData<KhoaHocDTO> GetKhoaHocByID(int khoaHocID)
        {
            var response = new ResponseData<KhoaHocDTO>();
            var khoaHoc = dbContext.KhoaHoc.FirstOrDefault(x => x.ID == khoaHocID);
            if (khoaHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Khóa học có ID '{khoaHocID}' không tồn tại !";
                return response;
            }
            response.Status = StatusCodes.Status200OK;
            response.Message = "Thành công !";
            response.Data = khoaHocConverter.EntityKhoaHocToDTO(khoaHoc);
            return response;
        }

        public ResponseData<KhoaHocDTO> CreateKhoaHoc(CreateKhoaHocRequest request)
        {
            var response = new ResponseData<KhoaHocDTO>();
            if (!dbContext.LoaiKhoaHoc.Any(x => x.ID == request.LoaiKhoaHocID))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Loại khóa học có ID '{request.LoaiKhoaHocID}' không tồn tại !";
                return response;
            }
            KhoaHoc khoaHoc = khoaHocConverter.CreateKhoaHoc(request);
            dbContext.KhoaHoc.Add(khoaHoc);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Thêm khóa học thành công !";
            response.Data = khoaHocConverter.EntityKhoaHocToDTO(khoaHoc);
            return response;
        }

        public ResponseData<KhoaHocDTO> UpdateKhoaHoc(int khoaHocID, UpdateKhoaHocRequest request)
        {
            var response = new ResponseData<KhoaHocDTO>();
            var khoaHoc = dbContext.KhoaHoc.FirstOrDefault(x => x.ID == khoaHocID);
            if (khoaHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Khóa học có ID '{khoaHocID}' không tồn tại !";
                return response;
            }
            if (!dbContext.LoaiKhoaHoc.Any(x => x.ID == request.LoaiKhoaHocID))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Loại khóa học có ID '{request.LoaiKhoaHocID}' không tồn tại !";
                return response;
            }
            var khoaHocUpdate = khoaHocConverter.UpdateKhoaHoc(khoaHoc, request);
            dbContext.KhoaHoc.Update(khoaHocUpdate);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Cập nhật khóa học thành công !";
            response.Data = khoaHocConverter.EntityKhoaHocToDTO(khoaHocUpdate);
            return response;
        }

        public ResponseData<KhoaHocDTO> RemoveKhoaHoc(int khoaHocID)
        {
            var response = new ResponseData<KhoaHocDTO>();
            var khoaHoc = dbContext.KhoaHoc.FirstOrDefault(x => x.ID == khoaHocID);
            if (khoaHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Khóa học có ID '{khoaHocID}' không tồn tại !";
                return response;
            }
            dbContext.KhoaHoc.Remove(khoaHoc);
            dbContext.SaveChanges();

            response.Status = StatusCodes.Status200OK;
            response.Message = "Xóa khóa học thành công !";
            response.Data = khoaHocConverter.EntityKhoaHocToDTO(khoaHoc);
            return response;
        }
    }
}
