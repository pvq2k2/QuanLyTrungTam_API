using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Handle.Request.ChuDeRequest;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Implement;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChuDeController : ControllerBase
    {
        private readonly IChuDeService _iChuDeService;

        public ChuDeController()
        {
            _iChuDeService = new ChuDeService();
        }

        [HttpPost("GetAllChuDe")]
        public IActionResult GetAllChuDe(Pagination pagination)
        {
            return Ok(_iChuDeService.GetAllChuDe(pagination));
        }

        [HttpGet("GetChuDeByID")]
        public IActionResult GetChuDeByID(int chuDeID)
        {
            return Ok(_iChuDeService.GetChuDeByID(chuDeID));
        }

        [HttpPost("CreateChuDe")]
        public IActionResult CreateChuDe(CreateChuDeRequest request)
        {
            return Ok(_iChuDeService.CreateChuDe(request));
        }

        [HttpPut("UpdateChuDe")]
        public IActionResult UpdateChuDe(int chuDeID, UpdateChuDeRequest request)
        {
            return Ok(_iChuDeService.UpdateChuDe(chuDeID, request));
        }

        [HttpDelete("RemoveChuDe")]
        public IActionResult RemoveChuDe(int chuDeID)
        {
            return Ok(_iChuDeService.RemoveChuDe(chuDeID));
        }
    }
}
