using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FashionWebsite.Models;
namespace FashionWebsite.Areas.PrivatePages.Data
{
    public class Include
    {   
        //phương thức đọc trong tài khoản session 
        public static TaiKhoan GetTaiKhoan()
        {
            TaiKhoan kq = new TaiKhoan();
            kq = HttpContext.Current.Session["DangNhap"] as TaiKhoan;
            return kq;

        }
        // lấy tên của tài khoản trong hệ thống 
        public static string GetTenTaiKhoan()
        {
            return GetTaiKhoan().taiKhoan1;
        }
    }
}