using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Handle.Request.TaiKhoanRequest;
using QuanLyTrungTam_API.Helper;
using QuanLyTrungTam_API.Service.Implement;
using QuanLyTrungTam_API.Service.Interface;

namespace QuanLyTrungTam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanService _iTaiKhoanService;

        public TaiKhoanController()
        {
            _iTaiKhoanService = new TaiKhoanService();
        }

        [HttpPost("GetAllTaiKhoan")]
        public IActionResult GetAllTaiKhoan(Pagination pagination)
        {
            return Ok(_iTaiKhoanService.GetAllTaiKhoan(pagination));
        }

        [HttpPost("GetTaiKhoanByName")]
        public IActionResult GetTaiKhoanByName(string name, Pagination pagination)
        {
            return Ok(_iTaiKhoanService.GetTaiKhoanByName(name, pagination));
        }

        [HttpGet("GetTaiKhoanByID")]
        public IActionResult GetTaiKhoanByID(int taiKhoanID)
        {
            return Ok(_iTaiKhoanService.GetTaiKhoanByID(taiKhoanID));
        }

        [HttpPost("CreateTaiKhoan")]
        public IActionResult CreateTaiKhoan(CreateTaiKhoanRequest request)
        {
            return Ok(_iTaiKhoanService.CreateTaiKhoan(request));
        }

        [HttpPut("UpdateTaiKhoan")]
        public IActionResult UpdateTaiKhoan(int taiKhoanID, UpdateTaiKhoanRequest request)
        {
            return Ok(_iTaiKhoanService.UpdateTaiKhoan(taiKhoanID, request));
        }

        [HttpDelete("RemoveTaiKhoan")]
        public IActionResult RemoveTaiKhoan(int taiKhoanID)
        {
            return Ok(_iTaiKhoanService.RemoveTaiKhoan(taiKhoanID));
        }
    }
}
