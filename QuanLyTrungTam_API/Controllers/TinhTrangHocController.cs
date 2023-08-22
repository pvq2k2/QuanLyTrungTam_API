using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Handle.Request.TinhTrangHocRequest;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Implement;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhTrangHocController : ControllerBase
    {
        private readonly ITinhTrangHocService _iTinhTrangHocService;

        public TinhTrangHocController()
        {
            _iTinhTrangHocService = new TinhTrangHocService();
        }

        [HttpPost("GetAllTinhTrangHoc")]
        public IActionResult GetAllTinhTrangHoc(Pagination pagination)
        {
            return Ok(_iTinhTrangHocService.GetAllTinhTrangHoc(pagination));
        }

        [HttpGet("GetTinhTrangHocByID")]
        public IActionResult GetTinhTrangHocByID(int tinhTrangHocID)
        {
            return Ok(_iTinhTrangHocService.GetTinhTrangHocByID(tinhTrangHocID));
        }

        [HttpPost("CreateTinhTrangHoc")]
        public IActionResult CreateTinhTrangHoc(CreateTinhTrangHocRequest request)
        {
            return Ok(_iTinhTrangHocService.CreateTinhTrangHoc(request));
        }

        [HttpPut("UpdateTinhTrangHoc")]
        public IActionResult UpdateTinhTrangHoc(int tinhTrangHocID, UpdateTinhTrangHocRequest request)
        {
            return Ok(_iTinhTrangHocService.UpdateTinhTrangHoc(tinhTrangHocID, request));
        }

        [HttpDelete("RemoveTinhTrangHoc")]
        public IActionResult RemoveTinhTrangHoc(int tinhTrangHocID)
        {
            return Ok(_iTinhTrangHocService.RemoveTinhTrangHoc(tinhTrangHocID));
        }
    }
}
