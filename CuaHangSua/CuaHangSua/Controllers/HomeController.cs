using CuaHangSua.Models;
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
        int pageSize = 9;
        public ActionResult Index(string category = null,int page=1)
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

            ProductListViewModel listProduct = new ProductListViewModel
            {
                Products = products
                            .Where(p => category == null || p.ThuongHieu.TenThuongHieu == category)
                            .OrderBy(p => p.SuaID)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                        products.Count() :
                        products.Where(e => e.ThuongHieu.TenThuongHieu == category).Count()
                },
                CurrentCategory = category
            };

            return View(listProduct);
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
        public PartialViewResult NavMenu()
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

        public ActionResult DetailProduct(int id)
        {
            ProductViewModel product = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:24554/api/");

                var responseTask = client.GetAsync(string.Format("product?id={0}",id));
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

            return View(product);
        }
    }
}
