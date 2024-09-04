using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionWebsite.Models;
namespace FashionWebsite.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index(string maSP)
        {
            ShopOnline_DemoEntities db = new ShopOnline_DemoEntities();
            SanPham x = db.SanPhams.Where(z => z.maSP == maSP).First<SanPham>();    
            ViewData["SanPhamCanXem"] = x;
            return View();
        }
    }
}