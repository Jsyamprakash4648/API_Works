using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAPI.DATA;
using Microsoft.AspNetCore.Mvc;

namespace MAPI.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class TravelDetailsControllers:ControllerBase
    {

         private readonly ApplicationDBContext _dbContext;
        public TravelDetailsControllers(ApplicationDBContext applicationDBContext)
        {
            _dbContext=applicationDBContext;
        }

        [HttpGet]
        public IActionResult Gettravel()
        {
            return Ok(_dbContext.travel.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Gettraveldetails(int id)
        {
            var travel=_dbContext.travel.FirstOrDefault(user1=>user1.TravelID==id);
            if(travel==null)
            {
                return NotFound();
            }
            return Ok(travel);
        }

        [HttpPost]
        public IActionResult Posttraveldetails([FromBody] TravelDetails travel)
        {
            _dbContext.travel.Add(travel);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
         public IActionResult Puttraveldetails(int id,[FromBody] TravelDetails travel)
         {
            
            var oldTravel=_dbContext.travel.FirstOrDefault(u=>u.TravelID==id);
            if(oldTravel==null)
            {
                return NotFound();
            }
           
            oldTravel.CardNumber=travel.CardNumber;
            oldTravel.TravelID=travel.TravelID;
            oldTravel.FromLocation=travel.FromLocation;
            oldTravel.ToLocation=travel.ToLocation;
            oldTravel.Date=travel.Date;
            oldTravel.TravelCost=travel.TravelCost;
            _dbContext.SaveChanges();
//              //you want to return NoContent or another appropriate responce
            return Ok();

         }

          [HttpDelete("{id}")]
         public IActionResult Deletetravel(int id)
         {

            var user2=_dbContext.travel.FirstOrDefault(u=> u.TravelID==id);
            if(user2==null)
            {
                return NotFound();
             }
            _dbContext.travel.Remove(user2);
            _dbContext.SaveChanges();
            //you might want to return NoContent or Another Appropriate content
            return Ok();

         }


    

    }
}