using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.QuyenHanRequest;

namespace QuanLyTrungTam_API.Handle.Converter
{
    public class QuyenHanConverter
    {
        public QuyenHanDTO EntityQuyenHanToDTO(QuyenHan quyenHan)
        {
            return new QuyenHanDTO
            {
                TenQuyenHan = quyenHan.TenQuyenHan,
            };
        }

        public QuyenHan CreateQuyenHan(CreateQuyenHanRequest request)
        {
            return new QuyenHan
            {
                TenQuyenHan = request.TenQuyenHan,
            };
        }

        public QuyenHan UpdateQuyenHan(QuyenHan quyenHan, UpdateQuyenHanRequest request)
        {
            quyenHan.TenQuyenHan = request.TenQuyenHan;

            return quyenHan;
        }
    }
}
