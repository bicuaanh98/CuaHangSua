using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangSua.Models.DAO
{
    public class HoaDonViewModel
    {
        public int HoaDonID { get; set; }

        public DateTime NgayLap { get; set; }

        public string DiaChiNhanHang { get; set; }

        public int? KhachHangID { get; set; }

        public KhachHangViewModel KhachHang { get; set; }
        
        public ICollection<ChiTietHDViewModel> HoaDon { get; set; }
    }
}