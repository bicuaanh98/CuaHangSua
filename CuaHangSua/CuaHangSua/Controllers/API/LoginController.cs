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
    public class LoginController : ApiController
    {
        Model1 db;
        public LoginController()
        {
            db = new Model1();
        }
        public IHttpActionResult PostLogin(KhachHangViewModel user)
        {
            KhachHangViewModel khachHang = null;
            khachHang = db.KhachHangs
                        .Where(k => k.Username == user.Username && k.Password == user.Password)
                        .Select(s=>new KhachHangViewModel()
                        {
                            KhachHangID=s.KhachHangID,
                            TenKhachHang=s.TenKhachHang,
                            SDT=s.SDT,
                            Email=s.Email,
                            GioiTinh=s.GioiTinh,
                            NgaySinh=s.NgaySinh
                        }).FirstOrDefault();
            if (khachHang == null)
            {
                return NotFound();
            }

            return Ok(khachHang);
        }
    }
}
