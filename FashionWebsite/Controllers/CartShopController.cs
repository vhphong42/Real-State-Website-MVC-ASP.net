using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionWebsite.Models;

namespace FashionWebsite.Controllers
{
    public class CartShopController : Controller
    {
        // GET: CartShop
        public ActionResult Index()
        {
              // lấy giỏ hàng từ session ra
                CartShop gh = Session["GioHang"] as CartShop;
               //truyền ra ngoài view
                ViewData["Cart"] = gh;
                 return View();
        }
        public ActionResult Increase(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            gh.addItem(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
        public ActionResult Decrease(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            gh.decrease(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
        public ActionResult RemoveItem(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            gh.deleteItem(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
    }
}