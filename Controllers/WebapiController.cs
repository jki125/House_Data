using House_Data.Data;
using House_Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace House_Data.Controllers
{
    [Route("Webapi/[controller]")]
    [ApiController]
    public class HouseDataController : Controller
    {
        private readonly House_DataContext _context;

        public HouseDataController(House_DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var houseListResult = JsonSerializer.Serialize(_context.House.ToList());

            return Json(houseListResult);
        }

        [HttpGet("{id}")]
        public ActionResult Index(int? id)
        {
           var houseList = _context.House.Where(v => v.id == id);
           var houseListResult = JsonSerializer.Serialize(houseList.ToList());

            return Json(houseListResult);
        }

        [HttpPost]
        public ActionResult AddHouseData([FromBody][Bind("id,name,region,Amount,area,houseType,houseAge,salesId,cDate,uDate")] House house)
        {
            house.Serial = Functions.getHouseSerial();
            house.salesId = 1;//看登入的user是誰
            house.cDate = DateTime.Now;
            house.uDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(house);
                _context.SaveChanges();
            }

            var houseListResult = JsonSerializer.Serialize(_context.House.ToList());
            return Json(houseListResult);

        }
        [HttpPut("{id}")]
        public ActionResult UpdateHouseData(int? id,[FromBody][Bind("id,name,region,Amount,area,houseType,houseAge,salesId,cDate,uDate")] House house)
        {
            return Content(house.region);
            //以下值不修改
            /*
            house.salesId = house_old.salesId;
            house.cDate = house_old.cDate;
            house.uDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(house);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseExists(house.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var houseListResult = JsonSerializer.Serialize(_context.House.ToList());
            return Json(houseListResult);*/

        }




    }
}
