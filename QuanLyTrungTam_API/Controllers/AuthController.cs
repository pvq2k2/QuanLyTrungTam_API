using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuanLyTrungTam_API.DBContext;
using QuanLyTrungTam_API.Handle.Request.LoginRequest;
using QuanLyTrungTam_API.Handle.Response;
using QuanLyTrungTam_API.Service.Implement;
using QuanLyTrungTam_API.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuanLyTrungTam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _dbContext;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = new AppDbContext();
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest request)
        {
            if (request != null)
            {
                var resultLoginCheck = _dbContext.TaiKhoan
                    .Where(e => e.TenTaiKhoan == request.TenTaiKhoan && e.MatKhau == request.MatKhau)
                    //.Include(x => x.QuyenHan)
                    .FirstOrDefault();

                if (resultLoginCheck == null)
                {
                    return BadRequest("Invalid Credentials");
                }
                else
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]!),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("ID", resultLoginCheck.ID.ToString()),
                        new Claim("TenNguoiDung", resultLoginCheck.TenNguoiDung),
                        new Claim("TenTaiKhoan", resultLoginCheck.TenTaiKhoan),
                        //new Claim("QuyenHan", resultLoginCheck.QuyenHan!.TenQuyenHan)
                    };


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    var response = new ResponseUser
                    {
                        TenNguoiDung = resultLoginCheck.TenNguoiDung,
                        TenTaiKhoan = resultLoginCheck.TenTaiKhoan,
                        AccessToken = new JwtSecurityTokenHandler().WriteToken(token)
                    };

                    return Ok(response);
                }
            }
            else
            {
                return BadRequest("No Data Posted");
            }
        }
    }
}
