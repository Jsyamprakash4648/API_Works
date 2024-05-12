using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MAPI;
using MAPI.DATA;
using System.Data.Entity;


namespace MAPI.Controllers
{
      
    [Route ("api/[controller]")]
    [ApiController]
    public class UserdetailsController:ControllerBase
    {

        private readonly ApplicationDBContext _dbContext;
        public UserdetailsController(ApplicationDBContext applicationDBContext)
        {
            _dbContext=applicationDBContext;
        }
        


        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(_dbContext.users.ToList());
        }
        

        [HttpGet("{id}")]
        public IActionResult GetUsedetails(int id)
        {
            var user=_dbContext.users.FirstOrDefault(user1=>user1.UserCardNumber==id);
            if(user==null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult PostUserdetails([FromBody] Userdetails user)
        {
            _dbContext.users.Add(user);
            _dbContext.SaveChanges();
            return Ok();
        }
        //upddate
        [HttpPut("{id}")]
         public IActionResult PutUserdetails(int id,[FromBody] Userdetails user)
         {
            var userOld=_dbContext.users.FirstOrDefault(u=>u.UserCardNumber==id);
            if(userOld==null)
            {
                return NotFound();
            }
            userOld.UserName=user.UserName;
            userOld.PhoneNumber=user.PhoneNumber;
            userOld.UserCardNumber=user.UserCardNumber;
            userOld.WalletBalance=user.WalletBalance;
            _dbContext.SaveChanges();
            
            
//              //you want to return NoContent or another appropriate responce
            return Ok();

         }

         [HttpDelete("{id}")]
         public IActionResult DeleteUser(int id)
         {

            var user2=_dbContext.users.FirstOrDefault(u=> u.UserCardNumber==id);
            if(user2==null)
            {
                return NotFound();
             }
            _dbContext.users.Remove(user2);
            _dbContext.SaveChanges();
            //you might want to return NoContent or Another Appropriate content
            return Ok();

         }
        
    }
}





 