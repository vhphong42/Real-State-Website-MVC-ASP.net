using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionWebsite.Models;


namespace FashionWebsite.Areas.PrivatePages.Controllers
{

    public class DMBaiVietController : Controller
    {
        private static ShopOnline_DemoEntities db = new ShopOnline_DemoEntities();
        public static bool daDuyet;
        // GET: PrivatePages/DMBaiViet
        [HttpGet]

        public ActionResult Index(string IsActive)
        {
            daDuyet = IsActive.Equals("1");
            UpdateData();
            return View();
        }
        [HttpPost]
        public ActionResult Delete(string maBaiViet)
        {
            BaiViet x = db.BaiViets.Find(maBaiViet);
            db.BaiViets.Remove(x);
            // Cập nhật data
            db.SaveChanges();
            // hiển thị trở lại ds khi xóa
            UpdateData();
            return View("Index");
        }
       [HttpPost]
        public ActionResult Active(string maBaiViet)
        {
            // dùng lệnh để xóa bài viết dựa vào mã bài viết 
            BaiViet x = db.BaiViets.Find(maBaiViet);
            x.daDuyet = !daDuyet;
            // Cập nhật data
            db.SaveChanges();

            // hiển thị trở lại ds khi xóa
            UpdateData();
            return View("Index");
        }
        public void UpdateData()
        {
            // dùng lệnh để xóa bài viết dựa vào mã bài viết 
            // Cập nhật data
            // hiển thị trở lại ds khi xóa
            List<BaiViet> l = db.BaiViets.Where(x => x.daDuyet == daDuyet).ToList<BaiViet>();
            ViewData["DSBV"] = l;
            ViewBag.tdCuaNut = daDuyet ? "Cấm  " : "Duyệt bài";
        }
    }
}