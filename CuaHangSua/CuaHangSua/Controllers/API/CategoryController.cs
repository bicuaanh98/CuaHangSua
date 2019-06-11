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
    public class CategoryController : ApiController
    {
        Model1 db;
        public CategoryController()
        {
            db = new Model1();
        }
        public IHttpActionResult GetAllCategories()
        {
            IList<ThuongHieuViewModel> categories = null;

            categories = db.ThuongHieux.Select(s => new ThuongHieuViewModel()
            {
                ThuongHieuID = s.ThuongHieuID,
                TenThuongHieu = s.TenThuongHieu,
                XuatXu = s.XuatXu
            }).ToList();

            if (categories.Count == 0)
            {
                return NotFound();
            }

            return Ok(categories);
        }
    }
}
