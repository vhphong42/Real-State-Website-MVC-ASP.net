using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionWebsite.Models;
namespace FashionWebsite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin
        [HttpGet]

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Account, string Password)

        {
            string mk = MaHoa.encryptSHA256(Password);
            //Đọc thông tin tài khoản từ Database thông qua model để xét có đúng tài khoản và mật khẩu không
            TaiKhoan tkdn = new ShopOnline_DemoEntities().TaiKhoans.Where(x => x.taiKhoan1.Equals(Account.ToLower().Trim()) && x.matKhau.Equals(mk)).First<TaiKhoan>();
            //lấy được thông tin từ databasse và dúng thì cho phép vào trang Admin
            bool isAuthentic = tkdn != null && tkdn.taiKhoan1.Equals(Account.ToLower().Trim()) && tkdn.matKhau.Equals(mk);
            if (isAuthentic)
            {
                Session["tkdn"] = tkdn;
                return RedirectToAction("Index", "Dashboard", new { area = "PrivatePages" });

            }

            // Chứng thực sai vẫn nạp Trang đăng nhập Login


            return View();
        }
    }
}