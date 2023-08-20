using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.LoaiBaiVietRequest;

namespace QuanLyTrungTam_API.Handle.Converter
{
    public class LoaiBaiVietConverter
    {
        public LoaiBaiVietDTO EntityLoaiBaiVietDTO(LoaiBaiViet loaiBaiViet)
        {
            return new LoaiBaiVietDTO {
                TenLoai = loaiBaiViet.TenLoai,
            };
        }

        public LoaiBaiViet CreateLoaiBaiViet(CreateLoaiBaiVietRequest request)
        {
            return new LoaiBaiViet
            {
                TenLoai = request.TenLoai,
            };
        }

        public LoaiBaiViet UpdateLoaiBaiViet(LoaiBaiViet loaiBaiViet, UpdateLoaiBaiVietRequest request)
        {
            loaiBaiViet.TenLoai = request.TenLoai;

            return loaiBaiViet;
        }
    }
}
