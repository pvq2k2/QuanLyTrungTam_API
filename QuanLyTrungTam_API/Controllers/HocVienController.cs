using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Handle.Request.HocVienRequest;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Implement;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocVienController : ControllerBase
    {
        private readonly IHocVienService _iHocVienService;

        public HocVienController()
        {
            _iHocVienService = new HocVienService();
        }

        [HttpPost("GetAllHocVien")]
        public IActionResult GetAllHocVien(Pagination pagination)
        {
            return Ok(_iHocVienService.GetAllHocVien(pagination));
        }

        [HttpPost("GetHocVienByName")]
        public IActionResult GetHocVienByName(string name, Pagination pagination)
        {
            return Ok(_iHocVienService.GetHocVienByName(name, pagination));
        }

        [HttpPost("GetHocVienByEmail")]
        public IActionResult GetHocVienByEmail(string email, Pagination pagination)
        {
            return Ok(_iHocVienService.GetHocVienByEmail(email, pagination));
        }

        [HttpGet("GetHocVienByID")]
        public IActionResult GetHocVienByID(int hocVienID)
        {
            return Ok(_iHocVienService.GetHocVienByID(hocVienID));
        }

        [HttpPost("CreateHocVien")]
        public IActionResult CreateHocVien(CreateHocVienRequest request)
        {
            return Ok(_iHocVienService.CreateHocVien(request));
        }

        [HttpPut("UpdateHocVien")]
        public IActionResult UpdateHocVien(int hocVienID, UpdateHocVienRequest request)
        {
            return Ok(_iHocVienService.UpdateHocVien(hocVienID, request));
        }

        [HttpDelete("RemoveHocVien")]
        public IActionResult RemoveHocVien(int hocVienID)
        {
            return Ok(_iHocVienService.RemoveHocVien(hocVienID));
        }
    }
}
