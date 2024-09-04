using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FashionWebsite.Models;
namespace FashionWebsite.Areas.PrivatePages.Models
{
    public class Include
        //py cho phép  đọc tài khoản từ session 
    {
        public static TaiKhoan GetTaiKhoan()
        {
            TaiKhoan kq = new TaiKhoan();
            kq = (TaiKhoan)HttpContext.Current.Session["TTDangNhap"];
            return kq;
            // lấy tên đn hệ thống
        }
        public static string GetTenTaiKhoan()
        {
            return GetTaiKhoan().taiKhoan1;
        }
    }
}