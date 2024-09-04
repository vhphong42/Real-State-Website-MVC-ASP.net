using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionWebsite.Models;

namespace FashionWebsite.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index(string maBV)
        {
            ShopOnline_DemoEntities db = new ShopOnline_DemoEntities();
            ViewData["dsbv"]  = db.BaiViets.Where(z => z.maBV.Equals(maBV)).First<BaiViet>();
            return View();
        }
    }
}