using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Handle.Request.QuyenHanRequest;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Implement;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuyenHanController : ControllerBase
    {
        private readonly IQuyenHanService _iQuyenHanService;

        public QuyenHanController()
        {
            _iQuyenHanService = new QuyenHanService();
        }

        [HttpPost("GetAllQuyenHan")]
        public IActionResult GetAllQuyenHan(Pagination pagination)
        {
            return Ok(_iQuyenHanService.GetAllQuyenHan(pagination));
        }

        [HttpGet("GetQuyenHanByID")]
        public IActionResult GetQuyenHanByID(int quyenHanID)
        {
            return Ok(_iQuyenHanService.GetQuyenHanByID(quyenHanID));
        }

        [HttpPost("CreateQuyenHan")]
        public IActionResult CreateQuyenHan(CreateQuyenHanRequest request)
        {
            return Ok(_iQuyenHanService.CreateQuyenHan(request));
        }

        [HttpPut("UpdateQuyenHan")]
        public IActionResult UpdateQuyenHan(int quyenHanID, UpdateQuyenHanRequest request)
        {
            return Ok(_iQuyenHanService.UpdateQuyenHan(quyenHanID, request));
        }

        [HttpDelete("RemoveQuyenHan")]
        public IActionResult RemoveQuyenHan(int quyenHanID)
        {
            return Ok(_iQuyenHanService.RemoveQuyenHan(quyenHanID));
        }
    }
}
