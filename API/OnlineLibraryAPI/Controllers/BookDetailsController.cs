using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryAPI.DATA;

namespace OnlineLibraryAPI.Controllers
{   [ApiController]
    [Route("api/[controller]")]
    public class BookDetailsController:ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public BookDetailsController(ApplicationDBContext applicationDBContext)
        {
            _dbContext=applicationDBContext;
        }


             
        [HttpGet]
        public IActionResult GetBookdetails()
        {
            return Ok(_dbContext.books.ToList());
        }

        //carrying data
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book=_dbContext.books.FirstOrDefault(bo=>bo.BookID==id);
            if(book==null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        //inserting
         [HttpPost]
        public IActionResult PostBooketails([FromBody] BookDetails book)
        {
            _dbContext.books.Add(book);
            _dbContext.SaveChanges();
            return Ok();
        }


         //update
        [HttpPut("{id}")]
         public IActionResult PutBookDetails(int id,[FromBody] BookDetails book)
         {
            var Oldbook=_dbContext.books.FirstOrDefault(book=>book.BookID==id);
            if(Oldbook==null)
            {
                return NotFound();
            }
            
            Oldbook.AuthorName=book.AuthorName;
            Oldbook.BookCount=book.BookCount;
            Oldbook.BookID=book.BookID;
            Oldbook.BookName=book.BookName;
            
            _dbContext.SaveChanges();
            return Ok();
         }

         //Delete

         [HttpDelete("{id}")]
         public IActionResult DeleteBook(int id)
         {

            var book=_dbContext.books.FirstOrDefault(br=> br.BookID==id);
            if(book==null)
            {
                return NotFound();
             }
            _dbContext.books.Remove(book);
            _dbContext.SaveChanges();
            //you might want to return NoContent or Another Appropriate content
            return Ok();

         }
 


        
    }
}