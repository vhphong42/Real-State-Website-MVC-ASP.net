using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionWebsite.Models;
using System.Data.Entity;

namespace FashionWebsite.Controllers
{
    public class CheckoutController : Controller
    {   
        // GET: Checkout
        [HttpGet]
        public ActionResult Index()
        {   
            // tạo 1 đối tượng khách hàng với thông tin mới truyền ra cho view
            KhachHang x = new KhachHang();
            // lấy thông tin đã mua hàng từ session và truyền cho view thông qua ViewData
            // lấy giỏ hàng từ sesion
            CartShop gh = Session["GioHang"] as CartShop;
            //truyền ra ngoài view
            ViewData["Cart"] = gh;
            return View(x);
        }
        [HttpPost]
        public ActionResult SaveToDataBase(KhachHang x)
        {
            //Sử dụng trang transaction để lưu dữ liệu đồng thời trên table khác nhau
            using (var context = new ShopOnline_DemoEntities())
            {
                using (DbContextTransaction trans = context.Database.BeginTransaction())
                {
                    try
                    {

                        // Table Khách hàng-----------------------------
                        x.maKH = x.soDT;
                        // Thêm khách hàng vào data model
                        context.KhachHangs.Add(x);
                        // Lưu lại khách hàng
                        context.SaveChanges();

                        // Tạo mới một đối tượng khách hàng và thêm đơn hàng
                        DonHang d = new DonHang();
                        d.soDH = string.Format("{0:yyMMddhhmm}", DateTime.Now);
                        d.maKH = x.maKH;
                        d.ngayGH = DateTime.Now;
                        d.ngayGH = DateTime.Now.AddDays(2);
                        d.taiKhoan = "admin";
                        d.diaChiGH = x.diaChi;
                        // Table[Đơn Hàng]-----------------------------
                        // Thêm đơn hàng vào data
                        context.DonHangs.Add(d);
                        // Lưu lại
                        context.SaveChanges();

                        // Lấy các đơn hàng trong ShoppingCart
                        CartShop gh = Session["GioHang"] as CartShop;
                        // Cập nhật thông tin đơn hàng
                        foreach (CtDonHang i in gh.SanPhamDC.Values)
                        {
                            i.soDH = d.soDH;
                            context.CtDonHangs.Add(i);
                        }
                        // Lưu lại chi tiết đơn hàng vào database
                        context.SaveChanges();
                        
                        // Finish and commit all  of action above
                        trans.Commit();
                        // Chuyển đến trang thông báo đã đặt hàng thành công
                        return RedirectToAction("Index", "Success");
                    }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
                    catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
                    {
                        trans.Rollback();
                    }
                }
            }
            // Nếu bị lỗi sẽ chuyển ra trang Checkout 
            return RedirectToAction("Index", "Checkout");
        }

    }
}