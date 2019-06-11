using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangSua.Models.DAO
{
    public class ProductViewModel
    {
        public int SuaID { get; set; }

        public string TenSua { get; set; }

        public string CachSuDung { get; set; }

        public string BaoQuan { get; set; }

        public string ThanhPhan { get; set; }

        public double DonGia { get; set; }

        public double KhoiLuong { get; set; }

        public string DonViTInh { get; set; }

        public LoViewModel Lo { get; set; }

        public string Anh { get; set; }
        public ThuongHieuViewModel ThuongHieu { get; set; }

    }
}