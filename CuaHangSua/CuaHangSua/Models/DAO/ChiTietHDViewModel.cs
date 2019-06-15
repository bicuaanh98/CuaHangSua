using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangSua.Models.DAO
{
    public class ChiTietHDViewModel
    {
        public HoaDonViewModel HoaDon { get; set; }
        public ProductViewModel Sua { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
    }
}