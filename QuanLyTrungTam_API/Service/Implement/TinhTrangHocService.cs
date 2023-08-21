using Microsoft.EntityFrameworkCore;
using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.Converter;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.TinhTrangHocRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Service.Implement
{
    public class TinhTrangHocService : BaseService, ITinhTrangHocService
    {
        public PageResult<TinhTrangHocDTO> GetAllTinhTrangHoc(Pagination pagination)
        {
            var query = dbContext.TinhTrangHoc.OrderByDescending(x => x.ID).AsQueryable();

            var result = PageResult<TinhTrangHoc>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<TinhTrangHocDTO>(pagination, tinhTrangHocConverter.ListEntityTinhTrangHocToDTO(result.ToList()));
        }

        public ResponseData<TinhTrangHocDTO> GetTinhTrangHocByID(int tinhTrangHocID)
        {
            var response = new ResponseData<TinhTrangHocDTO>();
            var tinhTrangHoc = dbContext.TinhTrangHoc.FirstOrDefault(x => x.ID == tinhTrangHocID);
            if (tinhTrangHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Tình trạng học có ID '{tinhTrangHocID}' không tồn tại !";
                return response;
            }
            response.Status = StatusCodes.Status200OK;
            response.Message = $"Thành công !";
            response.Data = tinhTrangHocConverter.EntityTinhTrangHocToDTO(tinhTrangHoc);
            return response;
        }

        public ResponseData<TinhTrangHocDTO> CreateTinhTrangHoc(CreateTinhTrangHocRequest request)
        {
            var response = new ResponseData<TinhTrangHocDTO>();
            TinhTrangHoc tinhTrangHoc = tinhTrangHocConverter.CreateTinhTrangHoc(request);
            dbContext.TinhTrangHoc.Add(tinhTrangHoc);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = $"Thêm tình trạng học thành công !";
            response.Data = tinhTrangHocConverter.EntityTinhTrangHocToDTO(tinhTrangHoc);
            return response;
        }

        public ResponseData<TinhTrangHocDTO> UpdateTinhTrangHoc(int tinhTrangHocID, UpdateTinhTrangHocRequest request)
        {
            var response = new ResponseData<TinhTrangHocDTO>();
            var tinhTrangHoc = dbContext.TinhTrangHoc.FirstOrDefault(x => x.ID == tinhTrangHocID);
            if (tinhTrangHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Tình trạng học có ID '{tinhTrangHocID}' không tồn tại !";
                return response;
            }
            TinhTrangHoc tinhTrangHocUpdate = tinhTrangHocConverter.UpdateTinhTrangHoc(tinhTrangHoc, request);
            dbContext.TinhTrangHoc.Add(tinhTrangHoc);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = $"Thêm tình trạng học thành công !";
            response.Data = tinhTrangHocConverter.EntityTinhTrangHocToDTO(tinhTrangHoc);
            return response;
        }

        public ResponseData<TinhTrangHocDTO> RemoveTinhTrangHoc(int tinhTrangHocID)
        {
            var response = new ResponseData<TinhTrangHocDTO>();
            var tinhTrangHoc = dbContext.TinhTrangHoc.FirstOrDefault(x => x.ID == tinhTrangHocID);
            if (tinhTrangHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Tình trạng học có ID '{tinhTrangHocID}' không tồn tại !";
                return response;
            }
            dbContext.TinhTrangHoc.Remove(tinhTrangHoc);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = $"Xóa tình trạng học thành công !";
            response.Data = tinhTrangHocConverter.EntityTinhTrangHocToDTO(tinhTrangHoc);
            return response;
        }
    }
}
