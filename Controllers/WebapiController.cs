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
            return Json(_context.House.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult Index(int? id)
        {
            var house = _context.House.Where(v => v.id == id).FirstOrDefault();
            if (house == null)
            {
                //return NotFound();
                return Json(new { });
            }

            return Json(house);
        }

        [HttpPost]
        public ActionResult AddHouseData([FromBody][Bind("id,name,region,Amount,area,houseType,houseAge,salesId,cDate,uDate,Serial")] House house)
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

            return Json(_context.House.ToList());

        }
        [HttpPut("{id}")]
        public ActionResult UpdateHouseData(int? id, [FromBody][Bind("name,region,Amount,area,houseType,houseAge,salesId,cDate,uDate")] House house)
        {
            var house_old = _context.House.Find(id);
            _context.Entry(house_old).State = EntityState.Detached;
            if (house_old == null)
            {
                return NotFound();
            }

            //以下值不修改
            house.id = house_old.id;
            house.Serial = house_old.Serial;
            house.salesId = house_old.salesId;
            house.cDate = house_old.cDate;
            //設定更新時間
            house.uDate = DateTime.Now;


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(house);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.House.Any(e => e.id == house.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return Json(_context.House.ToList());
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteHouseData(int id)
        {
            var house = _context.House.Find(id);
            if (house != null)
            {
                _context.House.Remove(house);
                _context.SaveChanges();
            }

            return Json(_context.House.ToList());
        }



    }
}
