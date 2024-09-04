using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionWebsite.Models;
using FashionWebsite.Areas.PrivatePages.Models;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionWebsite.Areas.PrivatePages.Controllers
{
    public class SanPhamMoiController : Controller
    {
        [HttpGet]
        // GET: PrivatePages/SanPhamMoi
        public ActionResult Index()
        {
            // thiết lập thông tin mặc định cbo đối tường cần gán 
            SanPham x = new SanPham();
            x.ngayDang = DateTime.Now;
            TaiKhoan tk = (TaiKhoan)Session["DangNhap"];
            x.taiKhoan = Include.GetTenTaiKhoan();

            // để đưa đường dẫn hình ra ngoài hiển thị trên image
            ViewBag.ddHinh = "/Content/img/products/06.jpg";
            return View(x);
        }
        

    }
}