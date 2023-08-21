using Microsoft.EntityFrameworkCore;
using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.DangKyHocRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Interface;
using System.Globalization;
using System.Linq;
using System.Text;

namespace QuanLyTrungTam_API.Service.Implement
{
    public class DangKyHocService : BaseService, IDangKyHocService
    {
        private static string RemoveDiacritics(string text)
        {
            string normalized = text.Normalize(NormalizationForm.FormD);
            var result = new StringBuilder();

            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    result.Append(c);
            }

            return result.ToString().Normalize(NormalizationForm.FormC);
        }

        private int CapNhatSoLuongHocVien(int khoaHocID)
        {
            var soLuongHocVien = dbContext.KhoaHoc.Where(x => x.ID == khoaHocID)
                .Include(x => x.ListDangKyHoc)
                .ThenInclude(x => x.TinhTrangHoc)
                .Count(x => x.TenKhoaHoc.ToLower().Contains("Đang học chính".ToLower())
                || x.TenKhoaHoc.ToLower().Contains("Học xong".ToLower())
                || x.TenKhoaHoc.ToLower().Contains("Chưa hoàn thành".ToLower()));

            return soLuongHocVien;
        }

        public PageResult<DangKyHocDTO> GetAllDangKyHoc(Pagination pagination)
        {
            var query = dbContext.DangKyHoc.OrderByDescending(x => x.ID).AsQueryable();

            var result = PageResult<DangKyHoc>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();

            return new PageResult<DangKyHocDTO>(pagination, dangKyHocConverter.ListEntityDangKyHocToDTO(result.ToList()));
        }

        public ResponseData<DangKyHocDTO> GetDangKyHocByID(int dangKyHocID)
        {
            var response = new ResponseData<DangKyHocDTO>();
            var dangKyHoc = dbContext.DangKyHoc.FirstOrDefault(x => x.ID == dangKyHocID);
            if (dangKyHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Đăng ký học có ID '{dangKyHocID}' không tồn tại !";
                return response;
            }
            response.Status = StatusCodes.Status200OK;
            response.Message = "Thành công !";
            response.Data = dangKyHocConverter.EntityDangKyHocToDTO(dangKyHoc);
            return response;
        }


        public ResponseData<DangKyHocDTO> CreateDangKyHoc(CreateDangKyHocRequest request)
        {
            var response = new ResponseData<DangKyHocDTO>();
            if (!dbContext.KhoaHoc.Any(x => x.ID == request.KhoaHocID))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Khóa học có ID '{request.KhoaHocID}' không tồn tại !";
                return response;
            }
            if (!dbContext.HocVien.Any(x => x.ID == request.HocVienID))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Học viên có ID '{request.HocVienID}' không tồn tại !";
                return response;
            }
            if (!dbContext.TaiKhoan.Any(x => x.ID == request.TaiKhoanID))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Tài khoản có ID '{request.TaiKhoanID}' không tồn tại !";
                return response;
            }
            var tinhTrangHoc = dbContext.TinhTrangHoc.FirstOrDefault(x => RemoveDiacritics(x.TenTinhTrang.ToLower()).Contains(RemoveDiacritics("Chờ duyệt").ToLower()));
            if (tinhTrangHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Tình trạng học không tồn tại !";
                return response;
            }
            DangKyHoc dangKyHoc = dangKyHocConverter.CreateDangKyHoc(request);
            dangKyHoc.TinhTrangHocID = tinhTrangHoc.ID;
            dbContext.DangKyHoc.Add(dangKyHoc);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Thêm đăng kí học thành công !";
            response.Data = dangKyHocConverter.EntityDangKyHocToDTO(dangKyHoc);
            return response;
        }

        public ResponseData<DangKyHocDTO> UpdateDangKyHoc(int dangKyHocID, UpdateDangKyHocRequest request)
        {
            var response = new ResponseData<DangKyHocDTO>();
            var dangKyHoc = dbContext.DangKyHoc.FirstOrDefault(x => x.ID == dangKyHocID);
            if (dangKyHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Đăng ký học có ID '{dangKyHocID}' không tồn tại !";
                return response;
            }
            var khoaHoc = dbContext.KhoaHoc.FirstOrDefault(x => x.ID == request.KhoaHocID);
            if (khoaHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Khóa học có ID '{request.KhoaHocID}' không tồn tại !";
                return response;
            }
            if (!dbContext.HocVien.Any(x => x.ID == request.HocVienID))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Học viên có ID '{request.HocVienID}' không tồn tại !";
                return response;
            }
            if (!dbContext.TaiKhoan.Any(x => x.ID == request.TaiKhoanID))
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Tài khoản có ID '{request.TaiKhoanID}' không tồn tại !";
                return response;
            }
            var tinhTrangHoc = dbContext.TinhTrangHoc.FirstOrDefault(x => x.ID == request.TinhTrangHocID);
            if (tinhTrangHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Tình trạng học có ID '{request.TinhTrangHocID}' không tồn tại !";
                return response;
            }
            DangKyHoc dangKyHocUpdate = dangKyHocConverter.UpdateDangKyHoc(dangKyHoc, request);
            if (!RemoveDiacritics(tinhTrangHoc.TenTinhTrang.ToLower()).Contains(RemoveDiacritics("Học xong").ToLower()))
            {
                if (RemoveDiacritics(tinhTrangHoc.TenTinhTrang.ToLower()).Contains(RemoveDiacritics("Đang học chính").ToLower()))
                {
                    if (dangKyHoc.TinhTrangHocID != request.TinhTrangHocID)
                    {
                        dangKyHocUpdate.NgayBatDau = DateTime.Now;
                        dangKyHocUpdate.NgayKetThuc = dangKyHoc.NgayBatDau.AddMonths(khoaHoc.ThoiGianHoc);
                    }
                }
                if (RemoveDiacritics(tinhTrangHoc.TenTinhTrang.ToLower()).Contains(RemoveDiacritics("Chưa hoàn thành").ToLower()))
                {
                    dangKyHocUpdate.NgayKetThuc = DateTime.MaxValue;
                }
            }

            khoaHoc.SoHocVien = CapNhatSoLuongHocVien(khoaHoc.ID);
            dbContext.KhoaHoc.Update(khoaHoc);
            dbContext.SaveChanges();


            dbContext.DangKyHoc.Update(dangKyHocUpdate);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Cập nhật đăng kí học thành công !";
            response.Data = dangKyHocConverter.EntityDangKyHocToDTO(dangKyHoc);
            return response;
        }

        public ResponseData<DangKyHocDTO> RemoveDangKyHoc(int dangKyHocID)
        {
            var response = new ResponseData<DangKyHocDTO>();
            var dangKyHoc = dbContext.DangKyHoc.FirstOrDefault(x => x.ID == dangKyHocID);
            if (dangKyHoc == null)
            {
                response.Status = StatusCodes.Status404NotFound;
                response.Message = $"Đăng ký học có ID '{dangKyHocID}' không tồn tại !";
                return response;
            }
            dbContext.DangKyHoc.Remove(dangKyHoc);
            dbContext.SaveChanges();
            response.Status = StatusCodes.Status200OK;
            response.Message = "Xóa đăng kí học thành công !";
            response.Data = dangKyHocConverter.EntityDangKyHocToDTO(dangKyHoc);
            return response;
        }
    }
}
