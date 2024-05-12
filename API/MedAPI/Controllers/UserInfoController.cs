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
    public class UserInfoController:ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public UserInfoController(ApplicationDBContext applicationDBContext)
        {
            _dbContext=applicationDBContext;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(_dbContext.users.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserdetails(int id)
        {
            var user1=_dbContext.users.FirstOrDefault(user1=>user1.UserID==id);
            if(user1==null)
            {
                return NotFound();
            }
            return Ok(user1);
        }


         [HttpPost]
        public IActionResult PostUserdetails([FromBody] Userinfo user1)
        {
            _dbContext.users.Add(user1);
            _dbContext.SaveChanges();
            return Ok();
        }

        //update
        [HttpPut("{id}")]
         public IActionResult PutOrderDetails(int id,[FromBody] Userinfo user1)
         {
            var Olduser=_dbContext.users.FirstOrDefault(u=>u.UserID==id);
            if(Olduser==null)
            {
                return NotFound();
            }

            Olduser.UserEmail=user1.UserEmail;
            Olduser.UserID=user1.UserID;
            Olduser.UserPassword=user1.UserPassword;
            Olduser.UserPhoneNumber=user1.UserPhoneNumber;
            Olduser.WalletBalance=user1.WalletBalance;
            _dbContext.SaveChanges();
            return Ok();
         }


         //delete

         [HttpDelete("{id}")]
         public IActionResult DeleteUser(int id)
         {

            var user2=_dbContext.users.FirstOrDefault(u=> u.UserID==id);
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