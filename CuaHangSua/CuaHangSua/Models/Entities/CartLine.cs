using CuaHangSua.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangSua.Models.Entities
{
    public class CartLine
    {
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
    }
}