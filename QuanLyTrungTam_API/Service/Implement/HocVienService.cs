using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.HocVienRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Service.Implement
{
    public class HocVienService : BaseService, IHocVienService
    {
        public PageResult<HocVienDTO> GetAllHocVien(Pagination pagination)
        {
            var query = dbContext.HocVien.OrderByDescending(x => x.ID).AsQueryable();

            var result = PageResult<HocVien>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<HocVienDTO>(pagination, hocVienConverter.ListEntityHocVienToDTO(result.ToList()));
        }

        public PageResult<HocVienDTO> GetHocVienByName(string name, Pagination pagination)
        {
            var query = dbContext.HocVien.OrderByDescending(x => x.ID).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.HoTen.ToLower().Contains(name.ToLower()));
            }

            var result = PageResult<HocVien>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<HocVienDTO>(pagination, hocVienConverter.ListEntityHocVienToDTO(result.ToList()));
        }

        public PageResult<HocVienDTO> GetHocVienByEmail(string email, Pagination pagination)
        {
            var query = dbContext.HocVien.OrderByDescending(x => x.ID).AsQueryable();

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(email.ToLower()));
            }

            var result = PageResult<HocVien>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<HocVienDTO>(pagination, hocVienConverter.ListEntityHocVienToDTO(result.ToList()));
        }

        public ResponseData<HocVienDTO> GetHocVienByID(int hocVienID)
        {
            var response = new ResponseData<HocVienDTO>();
            var hocVien = dbContext.HocVien.FirstOrDefault(x => x.ID == hocVienID);
            if (hocVien == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Học viên có ID '{hocVienID}' không tồn tại !";
                return response;
            }
            response.Status = StatusCodes.Status200OK;
            response.Message = "Thành công !";
            response.Data = hocVienConverter.EntityHocVienToDTO(hocVien);
            return response;
        }

        public ResponseData<HocVienDTO> CreateHocVien(CreateHocVienRequest request)
        {
            var response = new ResponseData<HocVienDTO>();
            if (dbContext.HocVien.Any(x => x.Email.ToLower().Contains(request.Email.ToLower()))) {
                response.Status = StatusCodes.Status400BadRequest;
                response.Message = "Email đã tồn tại !";
                return response;
            }
            if (dbContext.HocVien.Any(x => x.SDT.Contains(request.SDT)))
            {
                response.Status = StatusCodes.Status400BadRequest;
                response.Message = "Số điện thoại đã tồn tại !";
                return response;
            }
            HocVien hocVien = hocVienConverter.CreateHocVien(request);
            hocVien.HoTen = InputHelper.NormalizeName(hocVien.HoTen);
            dbContext.HocVien.Add(hocVien);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Thêm học viên thành công !";
            response.Data = hocVienConverter.EntityHocVienToDTO(hocVien);
            return response;
        }

        public ResponseData<HocVienDTO> UpdateHocVien(int hocVienID, UpdateHocVienRequest request)
        {
            var response = new ResponseData<HocVienDTO>();
            var hocVien = dbContext.HocVien.FirstOrDefault(x => x.ID == hocVienID);
            if (hocVien == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Học viên có ID '{hocVienID}' không tồn tại !";
                return response;
            }
            if (dbContext.HocVien.Any(x => x.Email.ToLower().Contains(request.Email.ToLower())))
            {
                response.Status = StatusCodes.Status400BadRequest;
                response.Message = "Email đã tồn tại !";
                return response;
            }
            if (dbContext.HocVien.Any(x => x.SDT.Contains(request.SDT)))
            {
                response.Status = StatusCodes.Status400BadRequest;
                response.Message = "Số điện thoại đã tồn tại !";
                return response;
            }
            HocVien hocVienUpdate = hocVienConverter.UpdateHocVien(hocVien, request);
            hocVienUpdate.HoTen = InputHelper.NormalizeName(hocVienUpdate.HoTen);
            dbContext.HocVien.Update(hocVienUpdate);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Cập nhật học viên thành công !";
            response.Data = hocVienConverter.EntityHocVienToDTO(hocVienUpdate);
            return response;
        }

        public ResponseData<HocVienDTO> RemoveHocVien(int hocVienID)
        {
            var response = new ResponseData<HocVienDTO>();
            var hocVien = dbContext.HocVien.FirstOrDefault(x => x.ID == hocVienID);
            if (hocVien == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Học viên có ID '{hocVienID}' không tồn tại !";
                return response;
            }
            dbContext.HocVien.Remove(hocVien);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Xóa học viên thành công !";
            response.Data = hocVienConverter.EntityHocVienToDTO(hocVien);
            return response;
        }
    }
}
