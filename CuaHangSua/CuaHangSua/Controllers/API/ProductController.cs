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

            products = db.Suas.Include("ThuongHieu")
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
                    Anh = s.Anh,
                    ThuongHieu=new ThuongHieuViewModel()
                    {
                        ThuongHieuID=s.ThuongHieuID,
                        TenThuongHieu=s.ThuongHieu.TenThuongHieu,
                        XuatXu=s.ThuongHieu.XuatXu
                    }
                }).ToList();
                               
            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        } 

        public IHttpActionResult GetDetailProduct(int id)
        {
            ProductViewModel product = null;

            product =(ProductViewModel)db.Suas.Include("Lo")
                .Where(s => s.SuaID == id)
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
                }).FirstOrDefault();


            if (product == null) 
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
