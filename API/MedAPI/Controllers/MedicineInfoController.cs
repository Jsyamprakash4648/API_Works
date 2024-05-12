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
    public class MedicineInfoController:ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public MedicineInfoController(ApplicationDBContext applicationDBContext)
        {
            _dbContext=applicationDBContext;
        }

        [HttpGet]
        public IActionResult GetMedicine()
        {
           return Ok(_dbContext.medicines.ToList());
        }


         [HttpGet("{id}")]
        public IActionResult GetMedicinedetails(int id)
        {
            var medicine1=_dbContext.medicines.FirstOrDefault(user1=>user1.MedicineID==id);
            if(medicine1==null)
            {
                return NotFound();
            }
            return Ok(medicine1);
        }

        
        [HttpPost]
        public IActionResult PostMedicinedetails([FromBody] MedicineInfo medicine1)
        {
            _dbContext.medicines.Add(medicine1);
            _dbContext.SaveChanges();
            return Ok();
        }

        //update
        [HttpPut("{id}")]
         public IActionResult PutOrderDetails(int id,[FromBody] MedicineInfo medicine1)
         {
            var Oldmedicine=_dbContext.medicines.FirstOrDefault(u=>u.MedicineID==id);
            if(Oldmedicine==null)
            {
                return NotFound();
            }

           Oldmedicine.MedicineCount=medicine1.MedicineCount;
           Oldmedicine.MedicineExpiry=medicine1.MedicineExpiry;
           Oldmedicine.MedicineID=medicine1.MedicineID;
           Oldmedicine.MedicineName=medicine1.MedicineName;
           Oldmedicine.MedicinePrice=medicine1.MedicinePrice;
            _dbContext.SaveChanges();
            return Ok();
          }


                  //delete
         [HttpDelete("{id}")]
         public IActionResult DeleteMedicine(int id)
         {

            var medicine2=_dbContext.medicines.FirstOrDefault(u=> u.MedicineID==id);
            if(medicine2==null)
            {
                return NotFound();
             }
            _dbContext.medicines.Remove(medicine2);
            _dbContext.SaveChanges();
            //you might want to return NoContent or Another Appropriate content
            return Ok();

         }
         

        
    }
}