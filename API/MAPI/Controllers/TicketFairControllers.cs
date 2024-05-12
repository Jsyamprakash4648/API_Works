using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAPI.DATA;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace MAPI.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class TicketFairControllers:ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public TicketFairControllers(ApplicationDBContext applicationDBContext)
        {
            _dbContext=applicationDBContext;
        }

        
        [HttpGet]
        public IActionResult Getticket()
        {
            return Ok(_dbContext.tickect.ToList());
        }


        [HttpGet("{id}")]
        public IActionResult Getticketdetails(int id)
        {
            var travel=_dbContext.tickect.FirstOrDefault(user1=>user1.TicketID==id);
            if(travel==null)
            {
                return NotFound();
            }
            return Ok(travel);
        }

        [HttpPost]
        public IActionResult Postticketdetails([FromBody] TicketFair ticket)
        {
            _dbContext.tickect.Add(ticket);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
         public IActionResult Putticketdetails(int id,[FromBody] TicketFair ticket)
         {
            
            var oldTicket=_dbContext.tickect.FirstOrDefault(u=>u.TicketID==id);
            if(oldTicket==null)
            {
                return NotFound();
            }
            oldTicket.TicketID=ticket.TicketID;
            oldTicket.FromLocation=ticket.FromLocation;
            oldTicket.ToLocation=ticket.ToLocation;
            oldTicket.TicketPrice=ticket.TicketPrice;
            _dbContext.SaveChanges();

//              //you want to return NoContent or another appropriate responce
            return Ok();

         }

         
          [HttpDelete("{id}")]
         public IActionResult Deleteticket(int id)
         {

            var ticket1=_dbContext.tickect.FirstOrDefault(u=> u.TicketID==id);
            if(ticket1==null)
            {
                return NotFound();
             }
            _dbContext.tickect.Remove(ticket1);
            _dbContext.SaveChanges();
            //you might want to return NoContent or Another Appropriate content
            return Ok();

         }

        
    }
}

    
