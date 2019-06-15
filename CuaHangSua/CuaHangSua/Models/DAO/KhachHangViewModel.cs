using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangSua.Models.DAO
{
    public class KhachHangViewModel
    {
        public int KhachHangID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string TenKhachHang { get; set; }

        public int? SDT { get; set; }

        public string Email { get; set; }

        public byte GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }
        
        public ICollection<HoaDonViewModel> HoaDons { get; set; }
    }
}