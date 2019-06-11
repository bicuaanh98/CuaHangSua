using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangSua.Models.DAO
{
    public class LoViewModel
    {
        public int LoID { get; set; }
        public DateTime NgaySanXuat { get; set; }
        public DateTime HanSuDung { get; set; }
        public int? SuaID { get; set; }
        public string NoiSanXuat { get; set; }
    }
}