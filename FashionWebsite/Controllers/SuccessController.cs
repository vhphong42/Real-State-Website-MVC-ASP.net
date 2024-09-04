using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionWebsite.Models;

namespace FashionWebsite.Controllers
{
    public class SuccessController : Controller
    {
        // GET: Success
        public ActionResult Index()
        {
            // lấy giỏ hàng từ session ra lần cuối
            CartShop gh = Session["GioHang"] as CartShop;
            //truyền ra ngoài view
            ViewData["Cart"] = gh;
            // Xóa giỏ hàng từ Sesion
            Session["GioHang"] = gh;
            return View();
        }
    }
}