using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryAPI.DATA
{   [Table("userDetails", Schema = "public")]
    public class UserDetails
    {   
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }

        public string  Password { get; set; }
         public string MailID { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
       
        public double WalletBalance { get; set; }
        
        public string[] Photo { get; set; }

    }
}