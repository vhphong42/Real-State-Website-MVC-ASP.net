using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionWebsite.Models;
namespace FashionWebsite.Areas.PrivatePages.Controllers
{
    public class LoaiSPController : Controller
    {
        private static bool isUpdate = false;
        // GET: PrivatePages/LoaiSP
        [HttpGet]
        public ActionResult Index()
        {
            List<LoaiSP> l = new ShopOnline_DemoEntities().LoaiSPs.OrderBy(x => x.tenLoai).ToList<LoaiSP>();
            ViewData["DSLoai"] = l;
            return View();

        }
        [HttpPost]
        public ActionResult Index(LoaiSP x)
        {
            ShopOnline_DemoEntities db = new ShopOnline_DemoEntities();
            //them loaiSP den data model
            if(!isUpdate)
                db.LoaiSPs.Add(x);
            else { 
                LoaiSP y = db.LoaiSPs.Find(x.maLoai);
                    y.tenLoai = x.tenLoai;
                    y.ghiChu = x.ghiChu;
                    isUpdate = false;
            }
            db.SaveChanges();// luu data den database
            //update list to view
            if (ModelState.IsValid)
                ModelState.Clear();
            ViewData["DSLoai"] = db.LoaiSPs.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            return View();
        }
        [HttpPost]
        public ActionResult Delete(string ml)
        {
            ShopOnline_DemoEntities db = new ShopOnline_DemoEntities();
            int ma = int.Parse(ml);
            //tim doi tuong loaiSP trong data model 
            LoaiSP x = db.LoaiSPs.Find(ma);
            // xoa loaiSP tu data model
            db.LoaiSPs.Remove(x);
            // update den database
            db.SaveChanges();
            // update data tren View 
            ViewData["DSLoai"] = db.LoaiSPs.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            return View("Index");
        }
        public ActionResult Update(string mlsc) 
        {
            ShopOnline_DemoEntities db = new ShopOnline_DemoEntities();
            int ma = int.Parse(mlsc);
            // tim LoaiSP trong datamodel by maLoai
            LoaiSP x = db.LoaiSPs.Find(ma);
            isUpdate = true;
            ViewData["DSLoai"] = db.LoaiSPs.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            return View("Index", x);


        }
    }
}