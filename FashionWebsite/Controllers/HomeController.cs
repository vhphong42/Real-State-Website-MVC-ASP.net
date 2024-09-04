
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionWebsite.Models;
namespace FashionWebsite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]

        public ActionResult Index()
        {
            List<SanPham> i = Commnon.getProductByLoaiSP(3);
            return View();
        }
        public ActionResult AddToCart (string maSP )
        {   // lấy giỏ hàng từ session ra
            CartShop gh = Session["GioHang"] as CartShop;
            // Thêm sản phẩm vừa mua vào giỏ hàng
            gh.addItem(maSP);
            // Cập nhật lại giỏ hàng 
            Session["GioHang"] = gh;
            return View("Index");
        }
        public ActionResult Index(String Search)

        {
            ShopOnline_DemoEntities db = new ShopOnline_DemoEntities();
            return View(db.SanPhams.Where(m => m.tenSP.Contains(Search) || Search == null && m.daDuyet == true));
        }
    }
    
}