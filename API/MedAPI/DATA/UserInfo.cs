using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedAPI.obj.DATA
{
     [Table("userInfo", Schema = "public")]
    public class Userinfo
    {
        [Key]
        public int UserID { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserPhoneNumber { get; set; }
        public int WalletBalance { get; set; }
    }
}