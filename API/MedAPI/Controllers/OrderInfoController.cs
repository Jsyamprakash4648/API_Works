using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedAPI.obj.DATA;
using Microsoft.AspNetCore.Mvc;


namespace MedAPI.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class OrderInfoController:ControllerBase
    {

        private readonly ApplicationDBContext _dbContext;
        public OrderInfoController(ApplicationDBContext applicationDBContext)
        {
            _dbContext=applicationDBContext;
        }

        [HttpGet]
        public IActionResult GetOrder()
        {
            return Ok(_dbContext.orders.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderdetails(int id)
        {
            var order1=_dbContext.orders.FirstOrDefault(user1=>user1.OrderID==id);
            if(order1==null)
            {
                return NotFound();
            }
            return Ok(order1);
        }

        [HttpPost]
        public IActionResult PostOrderdetails([FromBody] OrderInfo order1)
        {
            _dbContext.orders.Add(order1);
            _dbContext.SaveChanges();
            return Ok();
        }

        //update
        [HttpPut("{id}")]
         public IActionResult PutOrderDetails(int id,[FromBody] OrderInfo user1)
         {
            var Oldorder=_dbContext.orders.FirstOrDefault(u=>u.OrderID==id);
            if(Oldorder==null)
            {
                return NotFound();
            }

            Oldorder.OrderID=user1.OrderID;
            Oldorder.MedicinName=user1.MedicinName;
            Oldorder.OrderStatus=user1.OrderStatus;
            Oldorder.OrderTotalPrice=user1.OrderTotalPrice;
            Oldorder.UserName=user1.UserName;
            _dbContext.SaveChanges();
            return Ok();
         }

        //delete
         [HttpDelete("{id}")]
         public IActionResult DeleteOrder(int id)
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