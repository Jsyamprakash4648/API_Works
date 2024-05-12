using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineGroceryAPI.DATA;

namespace OnlineGroceryAPI.Controllers
{    [ApiController]
    [Route("api/[controller]")]
    public class cartItemControllers:ControllerBase
    {

        private readonly ApplicationDBContext _dbContext;
        public cartItemControllers(ApplicationDBContext applicationDBContext)
        {
            _dbContext=applicationDBContext;
        }



         
        [HttpGet]
        public IActionResult GetCartdetails()
        {
            return Ok(_dbContext.carts.ToList());
        }

        //carrying data
        [HttpGet("{id}")]
        public IActionResult Getcart(int id)
        {
            var cart=_dbContext.carts.FirstOrDefault(order1=>order1.CartID==id);
            if(cart==null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        //inserting
         [HttpPost]
        public IActionResult PostcartDetails([FromBody] CartItems cart)
        {
            _dbContext.carts.Add(cart);
            _dbContext.SaveChanges();
            return Ok();
        }


         //update
        [HttpPut("{id}")]
         public IActionResult PutcartDetails(int id,[FromBody] CartItems cart)
         {
            var Oldcart=_dbContext.carts.FirstOrDefault(u=>u.CartID==id);
            if(Oldcart==null)
            {
                return NotFound();
            }
            Oldcart.CartID=cart.CartID;
            Oldcart.OrderId=cart.OrderId;
            Oldcart.Price=cart.Price;
            Oldcart.ProductID=cart.ProductID;
            Oldcart.Productname=cart.Productname;
            Oldcart.UserID=cart.UserID;
        

            

            _dbContext.SaveChanges();
            return Ok();
         }

         //Delete

         [HttpDelete("{id}")]
         public IActionResult Deletecart(int id)
         {

            var order2=_dbContext.carts.FirstOrDefault(u=> u.CartID==id);
            if(order2==null)
            {
                return NotFound();
             }
            _dbContext.carts.Remove(order2);
            _dbContext.SaveChanges();
            //you might want to return NoContent or Another Appropriate content
            return Ok();

         }
        
    }
}