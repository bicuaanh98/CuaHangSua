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
    public class RegisterController : ApiController
    {
        Model1 db;
        public RegisterController()
        {
            db = new Model1();
        }
        public IHttpActionResult PostRegister(KhachHangViewModel user)
        {
            if ((db.KhachHangs.Where(k=>k.Username==user.Username).FirstOrDefault()) != null)
            {
                return NotFound();
            }
            db.KhachHangs.Add(new KhachHang()
            {
                KhachHangID=(db.KhachHangs.Max(k=>k.KhachHangID)+1),
                Username = user.Username,
                Password = user.Password,
                TenKhachHang = user.TenKhachHang,
                SDT = user.SDT,
                Email = user.Email
            });
            db.SaveChanges();
            return Ok();
        }
    }
}
