using CuaHangSua.Models.DAO;
using CuaHangSua.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSua.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public JsonResult AddToCart(int id,int quantity)
        {
            Cart cart = GetCart();
            ProductViewModel product = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:24554/api/");

                var responseTask = client.GetAsync(string.Format("product?id={0}", id));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ProductViewModel>();
                    readTask.Wait();

                    product = readTask.Result;
                }
                else
                {
                    product = null;
                }
            }
            if (product != null) 
            {
                cart.AddItem(product, quantity);
                Session["Cart"] = cart;
            }

            return Json(new { soluong = cart.TotalItem() });
        } 

        public ActionResult CartSummary()
        {
            return View();
        }

        public JsonResult UpdateQuantity(int id, int quantity)
        {
            Cart cart = GetCart();
            CartLine line = cart.Lines.Where(c => c.Product.SuaID == id).FirstOrDefault();
            line.Quantity = quantity;
            float lineValue =(float) line.Product.DonGia * quantity;
            float totalMoney = cart.ComputeTotalValue();
            return Json(new { soluong = cart.TotalItem(),linevalue=lineValue,totalmoney=totalMoney });
        } 

        public ActionResult RemoveFromCart(int id)
        {
            Cart cart = GetCart();
            ProductViewModel deleteProd = cart.Lines.Where(c => c.Product.SuaID == id).FirstOrDefault().Product;
            cart.RemoveLine(deleteProd);
            return RedirectToAction("CartSummary");
        }

        public ActionResult ClearCart()
        {
            Cart cart = GetCart();
            cart.Clear();
            return RedirectToAction("CartSummary");
        }

        public ActionResult Checkout()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult CheckoutStatus()
        {
            HoaDonViewModel hoaDon = new HoaDonViewModel();
            hoaDon.KhachHangID = (int)Session["KhachHangID"];
            hoaDon.DiaChiNhanHang = Request.Form["DiaChi"];
            hoaDon.HoaDon = new List<ChiTietHDViewModel>();
            foreach (var item in GetCart().Lines)
            {
                hoaDon.HoaDon.Add(new ChiTietHDViewModel()
                {
                    Sua = item.Product,
                    SoLuong = item.Quantity,
                    DonGia=item.Product.DonGia
                });
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:24554/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync("bill", hoaDon);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Session["CheckoutStatus"] = "Đặt hàng thành công ";
                    return View();
                }
            }
            Session["CheckoutStatus"] = "Hệ thống đang xảy ra lỗi quý khách vui lòng thử lại sau!";
            return View();
        }

    }
}