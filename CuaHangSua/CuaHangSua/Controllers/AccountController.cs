using CuaHangSua.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSua.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string TenDangNhap, string MatKhau, bool? NhoMatKhau)
        {
            if (TenDangNhap=="admin"&& MatKhau=="admin")
            {
                RedirectToAction("Index", "Admin");
            }

            KhachHangViewModel khachHang = new KhachHangViewModel();
            khachHang.Username = TenDangNhap;
            khachHang.Password = MatKhau;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:24554/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync("login",khachHang);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<KhachHangViewModel>();
                    khachHang = readTask.Result;
                    Session["KhachHangID"] = khachHang.KhachHangID;
                    Session["TenKhachHang"] = khachHang.TenKhachHang;
                    Session["TenDangNhap"] = khachHang.Username;
                    Session["SDT"] = khachHang.SDT;
                    Session["Email"] = khachHang.Email;
                    Session.Remove("Status");
                    return RedirectToAction("Index", "Home");
                }
            }
            Session["Status"] = "Tài khoản không đúng!";
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            Session.Remove("MatKhau");
            Session.Remove("TenKhachHang");
            Session.Remove("KhachHangID");
            Session.Remove("SDT");
            Session.Remove("Email");
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(KhachHangViewModel khachHang)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:24554/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync("register", khachHang);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Session["Status"] = "Đăng kí thành công! Mời quý khách đăng nhập";
                    return RedirectToAction("Login");
                }
            }
            Session["Status"] = "Tài khoản đã tồn tại!";
            return RedirectToAction("Register");          
        }
    }
}