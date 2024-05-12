using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryAPI.DATA
{    [Table("userDetails", Schema = "public")]
    public class UserDetails
    {   [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string MobileNumber { get; set; }
        public string MailID { get; set; }
        public double WalletBalance { get; set; }
        public string  Password { get; set; }
        public string[] Picture { get; set; }
    }
}