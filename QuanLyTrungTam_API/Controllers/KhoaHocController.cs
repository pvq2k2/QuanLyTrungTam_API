using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Handle.Request.KhoaHocRequest;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Implement;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoaHocController : ControllerBase
    {
        private readonly IKhoaHocService _iKhoaHocService;

        public KhoaHocController()
        {
            _iKhoaHocService = new KhoaHocService();
        }

        [HttpPost("GetAllKhoaHoc")]
        public IActionResult GetAllKhoaHoc(Pagination pagination)
        {
            return Ok(_iKhoaHocService.GetAllKhoaHoc(pagination));
        }

        [HttpPost("GetKhoaHocByName")]
        public IActionResult GetKhoaHocByName(string name, Pagination pagination)
        {
            return Ok(_iKhoaHocService.GetKhoaHocByName(name, pagination));
        }

        [HttpGet("GetKhoaHocByID")]
        public IActionResult GetKhoaHocByID(int khoaHocID)
        {
            return Ok(_iKhoaHocService.GetKhoaHocByID(khoaHocID));
        }

        [HttpPost("CreateKhoaHoc")]
        public IActionResult CreateKhoaHoc(CreateKhoaHocRequest request)
        {
            return Ok(_iKhoaHocService.CreateKhoaHoc(request));
        }

        [HttpPut("UpdateKhoaHoc")]
        public IActionResult UpdateKhoaHoc(int khoaHocID, UpdateKhoaHocRequest request)
        {
            return Ok(_iKhoaHocService.UpdateKhoaHoc(khoaHocID, request));
        }

        [HttpDelete("RemoveKhoaHoc")]
        public IActionResult RemoveKhoaHoc(int khoaHocID)
        {
            return Ok(_iKhoaHocService.RemoveKhoaHoc(khoaHocID));
        }
    }
}
