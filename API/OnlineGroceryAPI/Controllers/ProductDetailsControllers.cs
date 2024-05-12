using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineGroceryAPI.Controllers
{   [ApiController]
    [Route("api/[controller]")]
    public class ProductDetailsControllers:ControllerBase
    {
         private readonly ApplicationDBContext _dbContext;
        public ProductDetailsControllers(ApplicationDBContext applicationDBContext)
        {
            _dbContext=applicationDBContext;
        }


        
        [HttpGet]
        public IActionResult GetProductdetails()
        {
            return Ok(_dbContext.products.ToList());
        }

        //carrying data
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product=_dbContext.products.FirstOrDefault(user1=>user1.ProductID==id);
            if(product==null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //inserting
         [HttpPost]
        public IActionResult PostUserdetails([FromBody] ProductDetails product)
        {
            _dbContext.products.Add(product);
            _dbContext.SaveChanges();
            return Ok();
        }


         //update
        [HttpPut("{id}")]
         public IActionResult PutUserDetails(int id,[FromBody] ProductDetails product)
         {
            var Oldproduct=_dbContext.products.FirstOrDefault(u=>u.ProductID==id);
            if(Oldproduct==null)
            {
                return NotFound();
            }

           
            Oldproduct.PricePerQuantity=product.PricePerQuantity;
            Oldproduct.ProductDescription=product.ProductDescription;
            Oldproduct.ProductID=product.ProductID;
            Oldproduct.ProductImage=product.ProductImage;
            Oldproduct.ProductName=product.ProductName;
            Oldproduct.QuantityAvailable=product.QuantityAvailable;
            Oldproduct.ExpiryDate=product.ExpiryDate;
            Oldproduct.Purchasedate=product.Purchasedate;
                
            

            _dbContext.SaveChanges();
            return Ok();
         }

         //Delete

         [HttpDelete("{id}")]
         public IActionResult DeleteUser(int id)
         {

            var product2=_dbContext.products.FirstOrDefault(u=> u.ProductID==id);
            if(product2==null)
            {
                return NotFound();
             }
            _dbContext.products.Remove(product2);
            _dbContext.SaveChanges();
            //you might want to return NoContent or Another Appropriate content
            return Ok();

         }
 


    }
}