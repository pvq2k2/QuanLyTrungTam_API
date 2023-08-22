using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Handle.Request.DangKyHocRequest;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Implement;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DangKyHocController : ControllerBase
    {
        private readonly IDangKyHocService _iDangKyHocService;

        public DangKyHocController()
        {
            _iDangKyHocService = new DangKyHocService();
        }

        [HttpPost("GetAllDangKyHoc")]
        public IActionResult GetAllDangKyHoc(Pagination pagination)
        {
            return Ok(_iDangKyHocService.GetAllDangKyHoc(pagination));
        }

        [HttpGet("GetDangKyHocByID")]
        public IActionResult GetDangKyHocByID(int dangKyHocID)
        {
            return Ok(_iDangKyHocService.GetDangKyHocByID(dangKyHocID));
        }

        [HttpPost("CreateDangKyHoc")]
        public IActionResult CreateDangKyHoc(CreateDangKyHocRequest request)
        {
            return Ok(_iDangKyHocService.CreateDangKyHoc(request));
        }

        [HttpPut("UpdateDangKyHoc")]
        public IActionResult UpdateDangKyHoc(int dangKyHocID, UpdateDangKyHocRequest request)
        {
            return Ok(_iDangKyHocService.UpdateDangKyHoc(dangKyHocID, request));
        }

        [HttpDelete("RemoveDangKyHoc")]
        public IActionResult RemoveDangKyHoc(int dangKyHocID)
        {
            return Ok(_iDangKyHocService.RemoveDangKyHoc(dangKyHocID));
        }
    }
}
