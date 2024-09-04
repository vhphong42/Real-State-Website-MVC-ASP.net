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
    public class DangBaiVietController : Controller
    {   [HttpGet]
        // GET: PrivatePages/DangBaiViet
        public ActionResult Index()
        {
            // thiết lập thông tin mặc định cbo đối tường cần gán 
            BaiViet x = new BaiViet() ;
            x.ngayDang = DateTime.Now;
            x.soLanDoc = 0;
            TaiKhoan tk = (TaiKhoan)Session["DangNhap"];
            x.taiKhoan = Include.GetTenTaiKhoan();
            // để đưa đường dẫn hình ra ngoài hiển thị trên image
            ViewBag.ddHinh = "/Content/img/products/06.jpg";
            return View(x);
        }
      

    }
}