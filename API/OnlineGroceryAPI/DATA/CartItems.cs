using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryAPI.DATA
{   [Table("cartItems", Schema = "public")]
    public class CartItems
    {  [Key]

        public int CartID { get; set; }
        public int UserID { get; set; }

        public int OrderId { get; set; }

        public int ProductID { get; set; }

        public string Productname { get; set; }
        public double Price { get; set; }
        
            
    }
}


// CartID" serial primary key,
//   "UserID" int,
//   "OrderId" int,
//   "ProductID" int,
//   "Productname" varchar(250),
//   "Price" numeric(10,2))