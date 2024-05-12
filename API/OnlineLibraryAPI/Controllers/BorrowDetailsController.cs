using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryAPI.DATA;

namespace OnlineLibraryAPI.Controllers
{   [ApiController]
    [Route("api/[controller]")]
    public class BorrowDetailsController:ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public BorrowDetailsController(ApplicationDBContext applicationDBContext)
        {
            _dbContext=applicationDBContext;
        }

        
        [HttpGet]
        public IActionResult GetBorrowdetails()
        {
            return Ok(_dbContext.borrows.ToList());
        }

        //carrying data
        [HttpGet("{id}")]
        public IActionResult GetBorrow(int id)
        {
            var borrow=_dbContext.borrows.FirstOrDefault(borrow=>borrow.BorrowID==id);
            if(borrow==null)
            {
                return NotFound();
            }
            return Ok(borrow);
        }

        //inserting
         [HttpPost]
        public IActionResult PostBorrowdetails([FromBody] BorrowDetails borrow)
        {
            _dbContext.borrows.Add(borrow);
            _dbContext.SaveChanges();
            return Ok();
        }


         //update
        [HttpPut("{id}")]
         public IActionResult PutBorrowDetails(int id,[FromBody] BorrowDetails borrow)
         {
            var Oldborrow=_dbContext.borrows.FirstOrDefault(br=>br.BorrowID==id);
            if(Oldborrow==null)
            {
                return NotFound();
            }
            
            Oldborrow.BookID=borrow.BookID;
            Oldborrow.BorrowBookCount=borrow.BorrowBookCount;
            Oldborrow.BorrowedDate=borrow.BorrowedDate;
            Oldborrow.BorrowID=borrow.BorrowID;
            Oldborrow.PaidFineAmount=borrow.PaidFineAmount;
            Oldborrow.Status=borrow.Status;
            Oldborrow.UserID=borrow.UserID;
            
            _dbContext.SaveChanges();
            return Ok();
         }

         //Delete

         [HttpDelete("{id}")]
         public IActionResult DeleteBorrow(int id)
         {

            var user2=_dbContext.borrows.FirstOrDefault(br=> br.BorrowID==id);
            if(user2==null)
            {
                return NotFound();
             }
            _dbContext.borrows.Remove(user2);
            _dbContext.SaveChanges();
            //you might want to return NoContent or Another Appropriate content
            return Ok();

         }
 


    }
}