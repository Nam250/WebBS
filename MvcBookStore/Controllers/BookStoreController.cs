using MvcBookStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace MvcBookStore.Controllers
{
    public class BookStoreController : Controller
    {
        // Use DbContext to manage database
        QLBANSACHEntities database = new QLBANSACHEntities();
        private List<SACH> LaySachMoi(int soluong)
        {
            // Sắp xếp sách theo ngày cập nhật giảm dần, lấy đúng số lượng sách cần
            // Chuyển qua dạng danh sách kết quả đạt được
            return database.SACHes.OrderByDescending(sach =>
            sach.Ngaycapnhat).Take(soluong).ToList();
        }
        // GET: BookStore
        public ActionResult Index()
        {
            // Giả sử cần lấy 5 quyển sách mới cập nhật
            var dsSachMoi = LaySachMoi(5);
            return View(dsSachMoi);
        }
        public ActionResult LayChuDe()
        {
            var dsChuDe = database.CHUDEs.ToList();
            return PartialView(dsChuDe);
        }
        public ActionResult LayNhaXuatBan()
        {
            var dsNhaXB = database.NHAXUATBANs.ToList();
            return PartialView(dsNhaXB);
        }
        public ActionResult SPTheoChuDe(int id)
        {
            var dsSachtheochude = database.SACHes.Where(SACH => SACH.MaCD == id).ToList();
            return View("Index", dsSachtheochude);
        }
        public ActionResult SPTheoNXB(int id)
        {
            var dsSachNXB = database.SACHes.Where(SACH => SACH.MaNXB == id).ToList();   
            return View("Index",dsSachNXB);
        }
        public ActionResult Details(int id)

        {
             var sach = database.SACHes.FirstOrDefault(s => s.MaSach == id);
            return View(sach);
        }
    }
}