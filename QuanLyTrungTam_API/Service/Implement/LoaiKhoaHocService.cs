using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.LoaiKhoaHocRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Service.Implement
{
    public class LoaiKhoaHocService : BaseService, ILoaiKhoaHocService
    {
        public PageResult<LoaiKhoaHocDTO> GetAllLoaiKhoaHoc(Pagination pagination)
        {
            var query = dbContext.LoaiKhoaHoc.OrderByDescending(x => x.ID).AsQueryable();

            var result = PageResult<LoaiKhoaHoc>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<LoaiKhoaHocDTO>(pagination, loaiKhoaHocConverter.ListEntityLoaiKhoaHocToDTO(result.ToList()));
        }

        public ResponseData<LoaiKhoaHocDTO> GetLoaiKhoaHocByID(int loaiKhoaHocID)
        {
            var response = new ResponseData<LoaiKhoaHocDTO>();
            var loaiKhoaHoc = dbContext.LoaiKhoaHoc.FirstOrDefault(x => x.ID == loaiKhoaHocID);
            if (loaiKhoaHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Loại khóa học có ID '{loaiKhoaHocID}' không tồn tại !";
                return response;
            }
            response.Status = StatusCodes.Status200OK;
            response.Message = $"Thành công !";
            response.Data = loaiKhoaHocConverter.EntityLoaiKhoaHocToDTO(loaiKhoaHoc);
            return response;
        }

        public ResponseData<LoaiKhoaHocDTO> CreateLoaiKhoaHoc(CreateLoaiKhoaHocRequest request)
        {
            var response = new ResponseData<LoaiKhoaHocDTO>();
            LoaiKhoaHoc loaiKhoaHoc = loaiKhoaHocConverter.CreateLoaiKhoaHoc(request);
            dbContext.LoaiKhoaHoc.Add(loaiKhoaHoc);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = $"Thêm loại khóa học thành công !";
            response.Data = loaiKhoaHocConverter.EntityLoaiKhoaHocToDTO(loaiKhoaHoc);
            return response;
        }

        public ResponseData<LoaiKhoaHocDTO> UpdateLoaiKhoaHoc(int loaiKhoaHocID, UpdateLoaiKhoaHocRequest request)
        {
            var response = new ResponseData<LoaiKhoaHocDTO>();
            var loaiKhoaHoc = dbContext.LoaiKhoaHoc.FirstOrDefault(x => x.ID == loaiKhoaHocID);
            if (loaiKhoaHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Loại khóa học có ID '{loaiKhoaHocID}' không tồn tại !";
                return response;
            }
            LoaiKhoaHoc loaiKhoaHocUpdate = loaiKhoaHocConverter.UpdateLoaiKhoaHoc(loaiKhoaHoc, request);
            dbContext.LoaiKhoaHoc.Add(loaiKhoaHoc);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = $"Thêm loại khóa học thành công !";
            response.Data = loaiKhoaHocConverter.EntityLoaiKhoaHocToDTO(loaiKhoaHoc);
            return response;
        }

        public ResponseData<LoaiKhoaHocDTO> RemoveLoaiKhoaHoc(int loaiKhoaHocID)
        {
            var response = new ResponseData<LoaiKhoaHocDTO>();
            var loaiKhoaHoc = dbContext.LoaiKhoaHoc.FirstOrDefault(x => x.ID == loaiKhoaHocID);
            if (loaiKhoaHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Loại khóa học có ID '{loaiKhoaHocID}' không tồn tại !";
                return response;
            }
            dbContext.LoaiKhoaHoc.Remove(loaiKhoaHoc);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = $"Xóa loại khóa học thành công !";
            response.Data = loaiKhoaHocConverter.EntityLoaiKhoaHocToDTO(loaiKhoaHoc);
            return response;
        }
    }
}
