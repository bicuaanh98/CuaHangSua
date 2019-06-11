using CuaHangSua.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSua.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<ProductViewModel> products = null;

            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:24554/api/");

                var responseTask = client.GetAsync("product");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<ProductViewModel>>();
                    readTask.Wait();

                    products = readTask.Result;
                }
                else
                {
                    products = Enumerable.Empty<ProductViewModel>();
                }

            }

            return View(products);
        } 

        public ActionResult CategoryMenu()
        {
            IEnumerable<ThuongHieuViewModel> categories = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:24554/api/");

                var responseTask = client.GetAsync("category");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<ThuongHieuViewModel>>();
                    readTask.Wait();

                    categories = readTask.Result;
                }
                else
                {
                    categories = Enumerable.Empty<ThuongHieuViewModel>();
                }

            }

            return PartialView(categories);
        }
    }
}
