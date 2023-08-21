using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.ChuDeRequest;

namespace QuanLyTrungTam_API.Handle.Converter
{
    public class ChuDeConverter
    {
        public ChuDeDTO EntityChuDeToDTO(ChuDe chuDe)
        {
            return new ChuDeDTO
            {
                TenChuDe = chuDe.TenChuDe,
                NoiDung = chuDe.NoiDung
            };
        }

        public List<ChuDeDTO> ListEntityChuDeToDTO(List<ChuDe> listChuDe)
        {
            var listChuDeDTO = new List<ChuDeDTO>();
            foreach (var chuDe in listChuDe)
            {
                listChuDeDTO.Add(EntityChuDeToDTO(chuDe));
            }

            return listChuDeDTO;
        }

        public ChuDe CreateChuDe(CreateChuDeRequest request)
        {
            return new ChuDe
            {
                TenChuDe = request.TenChuDe,
                NoiDung = request.NoiDung,
                LoaiBaiVietID = request.LoaiBaiVietID
            };
        }

        public ChuDe UpdateChuDe(ChuDe chuDe, UpdateChuDeRequest request)
        {
            chuDe.TenChuDe = request.TenChuDe;
            chuDe.NoiDung = request.NoiDung;
            chuDe.LoaiBaiVietID = request.LoaiBaiVietID;

            return chuDe;
        }
    }
}
