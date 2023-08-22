using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Handle.Request.LoaiKhoaHocRequest;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Implement;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiKhoaHocController : ControllerBase
    {
        private readonly ILoaiKhoaHocService _iLoaiKhoaHocService;

        public LoaiKhoaHocController()
        {
            _iLoaiKhoaHocService = new LoaiKhoaHocService();
        }

        [HttpPost("GetAllLoaiKhoaHoc")]
        public IActionResult GetAllLoaiKhoaHoc(Pagination pagination)
        {
            return Ok(_iLoaiKhoaHocService.GetAllLoaiKhoaHoc(pagination));
        }

        [HttpGet("GetLoaiKhoaHocByID")]
        public IActionResult GetLoaiKhoaHocByID(int loaiKhoaHocID)
        {
            return Ok(_iLoaiKhoaHocService.GetLoaiKhoaHocByID(loaiKhoaHocID));
        }

        [HttpPost("CreateLoaiKhoaHoc")]
        public IActionResult CreateLoaiKhoaHoc(CreateLoaiKhoaHocRequest request)
        {
            return Ok(_iLoaiKhoaHocService.CreateLoaiKhoaHoc(request));
        }

        [HttpPut("UpdateLoaiKhoaHoc")]
        public IActionResult UpdateLoaiKhoaHoc(int loaiKhoaHocID, UpdateLoaiKhoaHocRequest request)
        {
            return Ok(_iLoaiKhoaHocService.UpdateLoaiKhoaHoc(loaiKhoaHocID, request));
        }

        [HttpDelete("RemoveLoaiKhoaHoc")]
        public IActionResult RemoveLoaiKhoaHoc(int loaiKhoaHocID)
        {
            return Ok(_iLoaiKhoaHocService.RemoveLoaiKhoaHoc(loaiKhoaHocID));
        }
    }
}
