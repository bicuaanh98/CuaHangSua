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
    public class BillController : ApiController
    {
        Model1 db;
        public BillController()
        {
            db = new Model1();
        }
        public IHttpActionResult PostBill(HoaDonViewModel hoaDon)
        {
            db.HoaDons.Add(new HoaDon()
            {
                HoaDonID = (db.HoaDons.Max(h=>h.HoaDonID)+1),
                NgayLap = DateTime.Now,
                DiaChiNhanHang = hoaDon.DiaChiNhanHang,
                KhachHangID = hoaDon.KhachHangID
            });
            foreach (var item in hoaDon.HoaDon)
            {
                db.ChiTietHoaDons.Add(new ChiTietHoaDon()
                {
                    HoaDonID = (db.HoaDons.Max(h=>h.HoaDonID)+1),
                    SuaID = item.Sua.SuaID,
                    SoLuong = item.SoLuong,
                    DonGia = item.DonGia
                });
            }
            db.SaveChanges();
            return Ok();
        }
    }
}
