using CuaHangSua.Models.DAO;
using CuaHangSua.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CuaHangSua.Controllers.API
{
    public class ProductController : ApiController
    {
        Model1 db;
        public ProductController()
        {
            db = new Model1();
        }
        public IHttpActionResult GetAllProducts()
        {
            IList<ProductViewModel> products = null;

            products = db.Suas.Include("Lo")
                .Select(s => new ProductViewModel()
                {
                    SuaID = s.SuaID,
                    TenSua = s.TenSua,
                    CachSuDung = s.CachSuDung,
                    BaoQuan = s.BaoQuan,
                    ThanhPhan = s.ThanhPhan,
                    DonGia = s.DonGia,
                    KhoiLuong = s.KhoiLuong,
                    DonViTInh = s.DonViTInh,
                    Anh = s.Anh
                }).ToList();
                               

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }
    }
}
