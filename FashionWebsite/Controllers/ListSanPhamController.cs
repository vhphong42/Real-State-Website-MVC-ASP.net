using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionWebsite.Models;

namespace FashionWebsite.Controllers
{
    public class ListSanPhamController : Controller
    {   [HttpGet]
        // GET: ListSanPham
        public ActionResult Index(String Search)

        {
            ShopOnline_DemoEntities db = new ShopOnline_DemoEntities();
            return View(db.SanPhams.Where(m => m.tenSP.Contains(Search) || Search == null && m.daDuyet == true));
        }

    }
}