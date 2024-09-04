using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionWebsite.Models
{
    public class CartShop
    {
       
            public string MaKH { get; set; }
            public string TaiKhoan { get; set; }
            public DateTime NgayDat { get; set; }
            public DateTime NgayGiao { get; set; }
            public string DiaChi { get; set; }


        //pt sortedlist ; <key> <value>
        public SortedList<string, CtDonHang> SanPhamDC { set; get; }
            //pthuc trả về true nếu k có sản phẩm nào mua trong hệ thống
            public CartShop()
            {
                this.MaKH = ""; this.TaiKhoan = ""; this.NgayDat = DateTime.Now; this.NgayGiao = DateTime.Now.AddDays(2);
                this.DiaChi = ""; 
                this.SanPhamDC = new SortedList<string, CtDonHang>();
            }
            public bool IsEmpty()
            {
                return (SanPhamDC.Keys.Count == 0);

            }
            //phương thức thêm 1 sản phẩm đã chọn vào giỏ hàng
            // có 2 tinh huống 
            public void addItem(string maSP)
            {
                if (SanPhamDC.Keys.Contains(maSP))
                {       // lấy sản phẩm từ trong giỏ hàng
                    CtDonHang x = SanPhamDC.Values[SanPhamDC.IndexOfKey(maSP)];
                    // tăng số lượng lên 1
                    x.soLuong++;
                //Bỏ trở lại trong giỏ hàng sau khi cập nhật số lượng
                    updateOneItem(x);
                }
                else
                {
                    CtDonHang i = new CtDonHang();
                    i.maSP = maSP;
                    i.soLuong = 1;
                    // lấy giá bán ; giảm giá từ Table sản phẩm
                    SanPham z = Commnon.getProductById(maSP);
                    i.giaBan = z.giaBan;
                    i.giamGia = z.giamGia;
                    // bỏ danh sách các sản phẩm đã chọn mua trong giỏ hàng của mình
                    SanPhamDC.Add(maSP, i);
                }
            }
        // hàm xóa sản phẩm cũ , rồi thêm mới trở lại
            public void updateOneItem( CtDonHang x)
            {
            this.SanPhamDC.Remove(x.maSP);
            this.SanPhamDC.Add(x.maSP,x);
            }
            // xóa 1 sản phẩm trong giỏ hàng
            public void deleteItem(string maSP)
            {
                if (SanPhamDC.Keys.Contains(maSP))

                    SanPhamDC.Remove(maSP);
            }
            // phương thức giảm số lượng hoặc xóa SP đã chọn ra khỏi cửa hàng
            public void decrease(string maSP)
            {
                if (SanPhamDC.Keys.Contains(maSP))
                {
                    CtDonHang x = SanPhamDC.Values[SanPhamDC.IndexOfKey(maSP)];
                    if (x.soLuong > 1)
                    {
                        x.soLuong--;
                    updateOneItem(x);
                }
                else
                        deleteItem(maSP);

                }

            }
            //phương thức tính tiền của 1 sản phẩm
            public long moneyOfOneProduct(CtDonHang x)
            {
                return (long)(x.giaBan*x.soLuong+(x.giaBan*x.soLuong*x.giamGia));
            }
            // Tổng tiền trong toàn bộ mặt hàng
            public long totalOfCartShop()
            {
                long kq = 0;
                foreach (CtDonHang i in SanPhamDC.Values)
                    kq += moneyOfOneProduct(i);
                return kq;
            }
        public long VAT()
        {

            return ((totalOfCartShop() * 5) / 100);
        }
        
        public long totalCart()
        {
            return (totalOfCartShop() + VAT());
        } 
    }
}