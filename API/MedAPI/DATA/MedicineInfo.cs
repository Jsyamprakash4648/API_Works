using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedAPI.obj.DATA
{    [Table("medicineInfo", Schema = "public")]
    public class MedicineInfo
    {
    [Key]
    public int MedicineID { get; set; }
    public string MedicineName { get; set; }
    public int MedicinePrice { get; set; }
    public int MedicineCount { get; set; }
    public DateTime MedicineExpiry { get; set; }
    }
}