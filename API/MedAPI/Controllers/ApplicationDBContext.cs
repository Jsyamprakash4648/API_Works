using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedAPI.obj.DATA;
using Microsoft.EntityFrameworkCore;

namespace MedAPI.Controllers
{
     public class ApplicationDBContext:DbContext,IDisposable
    {
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
        public DbSet<Userinfo> users { get; set; }
        public DbSet<OrderInfo> orders{ get; set; }
        public DbSet<MedicineInfo> medicines{ get; set; }


    
    }
}

    