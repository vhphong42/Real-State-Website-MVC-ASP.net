using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FashionWebsite.Models;

namespace FashionWebsite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start(object sender , EventArgs e)
        {
            Session["DangNhap"] = null;
            // cấp cho người dùng giỏ hàng chưa có gì cả

            Session["GioHang"] = new CartShop();
        }
    }
}
