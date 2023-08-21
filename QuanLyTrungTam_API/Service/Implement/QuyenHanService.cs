using Azure.Core;
using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.QuyenHanRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Service.Implement
{
    public class QuyenHanService : BaseService, IQuyenHanService
    {
        public PageResult<QuyenHanDTO> GetAllQuyenHan(Pagination pagination)
        {
            var query = dbContext.QuyenHan.OrderByDescending(x => x.ID).AsQueryable();

            var result = PageResult<QuyenHan>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<QuyenHanDTO>(pagination, quyenHanConverter.ListEntityQuyenHanToDTO(result.ToList()));
        }
        public ResponseData<QuyenHanDTO> GetQuyenHanByID(int quyenHanID)
        {
            var response = new ResponseData<QuyenHanDTO>();
            var quyenHan = dbContext.QuyenHan.FirstOrDefault(x => x.ID ==  quyenHanID);
            if (quyenHan == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Quyền hạn có ID '{quyenHanID}' không tồn tại !";
                return response;
            }
            response.Status = StatusCodes.Status200OK;
            response.Message = "Thành công !";
            response.Data = quyenHanConverter.EntityQuyenHanToDTO(quyenHan);
            return response;
        }
        public ResponseData<QuyenHanDTO> CreateQuyenHan(CreateQuyenHanRequest request)
        {
            var response = new ResponseData<QuyenHanDTO>();
            QuyenHan quyenHan = quyenHanConverter.CreateQuyenHan(request);
            dbContext.QuyenHan.Add(quyenHan);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Thêm quyền hạn thành công !";
            response.Data = quyenHanConverter.EntityQuyenHanToDTO(quyenHan);
            return response;
        }
        public ResponseData<QuyenHanDTO> UpdateQuyenHan(int quyenHanID, UpdateQuyenHanRequest request)
        {
            var response = new ResponseData<QuyenHanDTO>();
            var quyenHan = dbContext.QuyenHan.FirstOrDefault(x => x.ID == quyenHanID);
            if (quyenHan == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Quyền hạn có ID '{quyenHanID}' không tồn tại !";
                return response;
            }
            QuyenHan quyenHanUpdate = quyenHanConverter.UpdateQuyenHan(quyenHan, request);
            dbContext.QuyenHan.Update(quyenHanUpdate);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Cập nhật quyền hạn thành công !";
            response.Data = quyenHanConverter.EntityQuyenHanToDTO(quyenHanUpdate);
            return response;
        }
        public ResponseData<QuyenHanDTO> RemoveQuyenHan(int quyenHanID)
        {
            var response = new ResponseData<QuyenHanDTO>();
            var quyenHan = dbContext.QuyenHan.FirstOrDefault(x => x.ID == quyenHanID);
            if (quyenHan == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Quyền hạn có ID '{quyenHanID}' không tồn tại !";
                return response;
            }
            dbContext.QuyenHan.Remove(quyenHan);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Xóa quyền hạn thành công !";
            response.Data = quyenHanConverter.EntityQuyenHanToDTO(quyenHan);
            return response;
        }
    }
}
