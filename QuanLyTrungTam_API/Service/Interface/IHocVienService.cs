using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.HocVienRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Helper;

namespace QuanLyTrungTam_API.Service.Interface
{
    public interface IHocVienService
    {
        public PageResult<HocVienDTO> GetAllHocVien(Pagination pagination);
        public PageResult<HocVienDTO> GetHocVienByName(string name, Pagination pagination);
        public PageResult<HocVienDTO> GetHocVienByEmail(string email, Pagination pagination);
        public ResponseData<HocVienDTO> GetHocVienByID(int hocVienID);
        public ResponseData<HocVienDTO> CreateHocVien(CreateHocVienRequest request);
        public ResponseData<HocVienDTO> UpdateHocVien(int hocVienID, UpdateHocVienRequest request);
        public ResponseData<HocVienDTO> RemoveHocVien(int hocVienID);
    }
}
