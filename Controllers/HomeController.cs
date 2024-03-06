using House_Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace House_Data.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController

        private readonly House_DataContext _context;
        public HomeController(House_DataContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            ViewBag.OrderList = _context.Order
                .Where(v => v.SaleDate > DateTime.Today.AddDays(-180))
                .Include(v => v.Sales)
                .Include(v => v.House)
                .ToList();//半年內成交紀錄

            return View();
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
