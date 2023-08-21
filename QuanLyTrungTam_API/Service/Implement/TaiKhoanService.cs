using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.TaiKhoanRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Service.Implement
{
    public class TaiKhoanService : BaseService, ITaiKhoanService
    {
        public PageResult<TaiKhoanDTO> GetAllTaiKhoan(Pagination pagination)
        {
            var query = dbContext.TaiKhoan.OrderByDescending(x => x.ID).AsQueryable();

            var result = PageResult<TaiKhoan>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<TaiKhoanDTO>(pagination, taiKhoanConverter.ListEntityTaiKhoanToDTO(result.ToList()));
        }
        public PageResult<TaiKhoanDTO> GetTaiKhoanByName(string name, Pagination pagination)
        {
            var query = dbContext.TaiKhoan.OrderByDescending(x => x.ID).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.TenTaiKhoan.ToLower().Contains(name.ToLower()));
            }

            var result = PageResult<TaiKhoan>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<TaiKhoanDTO>(pagination, taiKhoanConverter.ListEntityTaiKhoanToDTO(result.ToList()));
        }
        public ResponseData<TaiKhoanDTO> GetTaiKhoanByID(int taiKhoanID)
        {
            var response = new ResponseData<TaiKhoanDTO>();
            var taiKhoan = dbContext.TaiKhoan.FirstOrDefault(x => x.ID == taiKhoanID);
            if (taiKhoan == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Tài khoản có ID '{taiKhoanID}' không tồn tại !";
                return response;
            }
            response.Status = StatusCodes.Status200OK;
            response.Message = "Thành công !";
            response.Data = taiKhoanConverter.EntityTaiKhoanToDTO(taiKhoan);
            return response;
        }
        public ResponseData<TaiKhoanDTO> CreateTaiKhoan(CreateTaiKhoanRequest request)
        {
            var response = new ResponseData<TaiKhoanDTO>();
            if (!dbContext.QuyenHan.Any(x => x.ID == request.QuyenHanID))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Quyền hạn có ID '{request.QuyenHanID}' không tồn tại !";
                return response;
            }
            if (dbContext.TaiKhoan.Any(x => x.TenTaiKhoan.ToLower().Contains(request.TenTaiKhoan.ToLower())))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = "Tên tài khoản đã tồn tại !";
                return response;
            }
            if (!InputHelper.RegexPassword(request.MatKhau))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = "Mật khẩu phải có chữ số và kí tự đặc biệt !";
                return response;
            }
            TaiKhoan taiKhoan = taiKhoanConverter.CreateTaiKhoan(request);
            dbContext.TaiKhoan.Add(taiKhoan);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Thêm tài khoản thành công !";
            response.Data = taiKhoanConverter.EntityTaiKhoanToDTO(taiKhoan);
            return response;
            
        }
        public ResponseData<TaiKhoanDTO> UpdateTaiKhoan(int taiKhoanID, UpdateTaiKhoanRequest request)
        {
            var response = new ResponseData<TaiKhoanDTO>();
            var taiKhoan = dbContext.TaiKhoan.FirstOrDefault(x => x.ID == taiKhoanID);
            if (taiKhoan == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Tài khoản có ID '{taiKhoanID}' không tồn tại !";
                return response;
            }
            if (!dbContext.QuyenHan.Any(x => x.ID == request.QuyenHanID))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Quyền hạn có ID '{request.QuyenHanID}' không tồn tại !";
                return response;
            }
            if (dbContext.TaiKhoan.Any(x => x.TenTaiKhoan.ToLower().Contains(request.TenTaiKhoan.ToLower())))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = "Tên tài khoản đã tồn tại !";
                return response;
            }
            TaiKhoan taiKhoanUpdate = taiKhoanConverter.UpdateTaiKhoan(taiKhoan, request);
            dbContext.TaiKhoan.Update(taiKhoanUpdate);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Cập nhật tài khoản thành công !";
            response.Data = taiKhoanConverter.EntityTaiKhoanToDTO(taiKhoan);
            return response;
        }
        public ResponseData<TaiKhoanDTO> RemoveTaiKhoan(int taiKhoanID)
        {
            var response = new ResponseData<TaiKhoanDTO>();
            var taiKhoan = dbContext.TaiKhoan.FirstOrDefault(x => x.ID == taiKhoanID);
            if (taiKhoan == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Tài khoản có ID '{taiKhoanID}' không tồn tại !";
                return response;
            }
            dbContext.TaiKhoan.Remove(taiKhoan);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Xóa tài khoản thành công !";
            response.Data = taiKhoanConverter.EntityTaiKhoanToDTO(taiKhoan);
            return response;
        }
    }
}
