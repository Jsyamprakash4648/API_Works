using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedAPI.obj.DATA
{
    [Table("orderInfo", Schema = "public")]
    public class OrderInfo
    { 
    [Key]
    public int OrderID { get; set; }
    public string UserName { get; set; }
    public string MedicinName { get; set; }
    public int OrderTotalPrice { get; set; }
    public string OrderStatus { get; set; }
    }
}