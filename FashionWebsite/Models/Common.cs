using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FashionWebsite.Models;

namespace FashionWebsite.Models
{
    public class Commnon
    {
        static DbContext cn = new DbContext("name=ShopOnline_DemoEntities");
        // lấy tất cả loại trong data
        public static List<SanPham> getProduct()
        {
            List<SanPham> i = new List<SanPham>();
            //-- khai báo đối tượng đại diện cho database
            DbContext n = new DbContext("name=ShopOnline_DemoEntities");
            //-- lấy dữ liệu
            i = n.Set<SanPham>().ToList<SanPham>();
            return i;
        }
        public static List<SanPham> getProductByAdmin()
        {
            return new DbContext("name=ShopOnline_DemoEntities").Set<SanPham>().Take(6).ToList<SanPham>();

        }

        // lấy theo từng loại trong data
        public static List<LoaiSP> getLoai()
        {
            return new DbContext("name=ShopOnline_DemoEntities").Set<LoaiSP>().ToList<LoaiSP>();
        }
        // lấy ra n bài viết từ database
        public static List<SanPham> getProductByLoaiSP( int maLoai)
        {
            List<SanPham> i = new List<SanPham>();
            //-- khai báo đối tượng đại diện cho database
            DbContext n = new DbContext("name=ShopOnline_DemoEntities");
            //-- lấy dữ liệu
            i = n.Set<SanPham>().Where( x => x.maLoai == maLoai ).ToList<SanPham>();
            return i;
        }
        public static List<BaiViet> GetBaiViets(int n )
        {
            List<BaiViet> l = new List<BaiViet>();
            ShopOnline_DemoEntities db = new ShopOnline_DemoEntities();
            l = db.BaiViets.OrderByDescending(bv => bv.ngayDang).Take(n).ToList<BaiViet>();

            return l;
        }
        //pthuc cho phép  lấy thông tin của một sản phẩm dựa vào mã của sản phẩm ;
        public static SanPham getProductById(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP);     
        }
        //lấy đưuòng dẫn hình dựa vào mã SP
        public static string getImageOfProductByID(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP).hinhDD;

        }
        public static string getNameOfProductByID(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP).tenSP;

        }
        public static List<KhachHang> getKhachHang()
        {
            List<KhachHang> i = new List<KhachHang>();
            //-- khai báo đối tượng đại diện cho database
            DbContext n = new DbContext("name=ShopOnline_DemoEntities");
            //-- lấy dữ liệu
            i = n.Set<KhachHang>().ToList<KhachHang>();
            return i;
        }
        public static List<CtDonHang> getCtDonHang()
        {
            List<CtDonHang> i = new List<CtDonHang>();
            //-- khai báo đối tượng đại diện cho database
            DbContext n = new DbContext("name=ShopOnline_DemoEntities");
            //-- lấy dữ liệu
            i = n.Set<CtDonHang>().ToList<CtDonHang>();
            return i;
        }
        public static List<DonHang> getDonHang()
        {
            List<DonHang> i = new List<DonHang>();
            //-- khai báo đối tượng đại diện cho database
            DbContext n = new DbContext("name=ShopOnline_DemoEntities");
            //-- lấy dữ liệu
            i = n.Set<DonHang>().ToList<DonHang>();
            return i;
        }
    }
   
}