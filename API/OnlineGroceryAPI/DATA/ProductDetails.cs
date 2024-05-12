using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryAPI
{   [Table("productDetails", Schema = "public")]
    public class ProductDetails
    {   
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int QuantityAvailable { get; set; }
        public string ProductDescription { get; set; }
        public double PricePerQuantity { get; set; }
        public DateTime Purchasedate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string[] ProductImage { get; set; }





        // --Purchasedate--ExpiryDate
    }
}