using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Handle.Request.BaiVietRequest;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Implement;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        private readonly IBaiVietService _iBaiVietService;

        public BaiVietController()
        {
            _iBaiVietService = new BaiVietService();
        }

        [HttpPost("GetAllBaiViet")]
        public IActionResult GetAllBaiViet(Pagination pagination) {
            return Ok(_iBaiVietService.GetAllBaiViet(pagination));
        }

        [HttpPost("GetBaiVietByTenBaiViet")]
        public IActionResult GetBaiVietByTenBaiViet(string tenBaiViet, Pagination pagination)
        {
            return Ok(_iBaiVietService.GetBaiVietByTenBaiViet(tenBaiViet, pagination));
        }

        [HttpGet("GetBaiVietByID")]
        public IActionResult GetBaiVietByID(int baiVietID)
        {
            return Ok(_iBaiVietService.GetBaiVietByID(baiVietID));
        }

        [HttpPost("CreateBaiViet")]
        public IActionResult CreateBaiViet(CreateBaiVietRequest request)
        {
            return Ok(_iBaiVietService.CreateBaiViet(request));
        }

        [HttpPut("UpdateBaiViet")]
        public IActionResult UpdateBaiViet(int baiVietID, UpdateBaiVietRequest request) { 
            return Ok(_iBaiVietService.UpdateBaiViet(baiVietID, request));
        }

        [HttpDelete("RemoveBaiViet")]
        public IActionResult RemoveBaiViet(int baiVietID)
        {
            return Ok(_iBaiVietService.RemoveBaiViet(baiVietID));
        }
    }
}
