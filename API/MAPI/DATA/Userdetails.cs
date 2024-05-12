using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAPI.DATA
{
    [Table("userdetails", Schema = "public")] 
    public class Userdetails
    {
        [Key]
        public int  UserCardNumber { get; set; } //userCardNumber

        public string? UserName { get; set; }

        public string PhoneNumber { get; set; }

        public int WalletBalance { get; set; }

    }
}