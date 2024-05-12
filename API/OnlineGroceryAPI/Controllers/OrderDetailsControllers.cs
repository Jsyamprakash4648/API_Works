using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineGroceryAPI.DATA;

namespace OnlineGroceryAPI.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsControllers:ControllerBase
    {
         private readonly ApplicationDBContext _dbContext;
        public OrderDetailsControllers(ApplicationDBContext applicationDBContext)
        {
            _dbContext=applicationDBContext;
        }


        
        [HttpGet]
        public IActionResult Getorderdetails()
        {
            return Ok(_dbContext.orders.ToList());
        }

        //carrying data
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order=_dbContext.orders.FirstOrDefault(order1=>order1.OrderID==id);
            if(order==null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        //inserting
         [HttpPost]
        public IActionResult PostOrderetails([FromBody] OrderDetails order)
        {
            _dbContext.orders.Add(order);
            _dbContext.SaveChanges();
            return Ok();
        }


         //update
        [HttpPut("{id}")]
         public IActionResult PutOrderDetails(int id,[FromBody] OrderDetails order)
         {
            var Oldorder=_dbContext.orders.FirstOrDefault(u=>u.OrderID==id);
            if(Oldorder==null)
            {
                return NotFound();
            }
            Oldorder.OrderID=order.OrderID;
            Oldorder.PriceOfOrder=order.PriceOfOrder;
            Oldorder.UserID=order.UserID;

            

            _dbContext.SaveChanges();
            return Ok();
         }

         //Delete

         [HttpDelete("{id}")]
         public IActionResult Deleteorder(int id)
         {

            var order2=_dbContext.orders.FirstOrDefault(u=> u.OrderID==id);
            if(order2==null)
            {
                return NotFound();
             }
            _dbContext.orders.Remove(order2);
            _dbContext.SaveChanges();
            //you might want to return NoContent or Another Appropriate content
            return Ok();

         }

    }
}