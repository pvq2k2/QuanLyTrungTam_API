using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Handle.Request.LoaiBaiVietRequest;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Implement;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiBaiVietController : ControllerBase
    {
        private readonly ILoaiBaiVietService _iLoaiBaiVietService;

        public LoaiBaiVietController()
        {
            _iLoaiBaiVietService = new LoaiBaiVietService();
        }

        [HttpPost("GetAllLoaiBaiViet")]
        public IActionResult GetAllLoaiBaiViet(Pagination pagination)
        {
            return Ok(_iLoaiBaiVietService.GetAllLoaiBaiViet(pagination));
        }

        [HttpGet("GetLoaiBaiVietByID")]
        public IActionResult GetLoaiBaiVietByID(int loaiBaiVietID)
        {
            return Ok(_iLoaiBaiVietService.GetLoaiBaiVietByID(loaiBaiVietID));
        }

        [HttpPost("CreateLoaiBaiViet")]
        public IActionResult CreateLoaiBaiViet(CreateLoaiBaiVietRequest request)
        {
            return Ok(_iLoaiBaiVietService.CreateLoaiBaiViet(request));
        }

        [HttpPut("UpdateLoaiBaiViet")]
        public IActionResult UpdateLoaiBaiViet(int loaiBaiVietID, UpdateLoaiBaiVietRequest request)
        {
            return Ok(_iLoaiBaiVietService.UpdateLoaiBaiViet(loaiBaiVietID, request));
        }

        [HttpDelete("RemoveLoaiBaiViet")]
        public IActionResult RemoveLoaiBaiViet(int loaiBaiVietID)
        {
            return Ok(_iLoaiBaiVietService.RemoveLoaiBaiViet(loaiBaiVietID));
        }
    }
}
