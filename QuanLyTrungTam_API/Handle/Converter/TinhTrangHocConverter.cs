﻿using QuanLyTrungTam_API.Entities;
using QuanLyTrungTam_API.Handle.DTOs;
using QuanLyTrungTam_API.Handle.Request.TinhTrangHocRequest;

namespace QuanLyTrungTam_API.Handle.Converter
{
    public class TinhTrangHocConverter
    {
        public TinhTrangHocDTO EntityTinhTrangHocToDTO(TinhTrangHoc tinhTrangHoc)
        {
            return new TinhTrangHocDTO
            {
                TenTinhTrang = tinhTrangHoc.TenTinhTrang,
            };
        }

        public TinhTrangHoc CreateTinhTrangHoc(CreateTinhTrangHocRequest request)
        {
            return new TinhTrangHoc
            {
                TenTinhTrang = request.TenTinhTrang,
            };
        }

        public TinhTrangHoc UpdateTinhTrangHoc(TinhTrangHoc tinhTrangHoc, UpdateTinhTrangHocRequest request)
        {
            tinhTrangHoc.TenTinhTrang = request.TenTinhTrang;

            return tinhTrangHoc;
        }
    }
}
