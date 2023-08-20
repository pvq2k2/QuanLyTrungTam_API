using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.TaiKhoanRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;

namespace QuanLyTrungTam_API.Service.Interface
{
    public interface ITaiKhoanService
    {
        public PageResult<TaiKhoanDTO> GetAllTaiKhoan(Pagination pagination);
        public PageResult<TaiKhoanDTO> GetTaiKhoanByName(string name, Pagination pagination);
        public ResponseData<TaiKhoanDTO> GetTaiKhoanByID(int taiKhoanID);
        public ResponseData<TaiKhoanDTO> CreateTaiKhoan(CreateTaiKhoanRequest request);
        public ResponseData<TaiKhoanDTO> UpdateTaiKhoan(int taiKhoanID, UpdateTaiKhoanRequest request);
        public ResponseData<TaiKhoanDTO> RemoveTaiKhoan(int taiKhoanID);
    }
}
