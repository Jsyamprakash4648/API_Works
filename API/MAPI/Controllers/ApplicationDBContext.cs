using System;
using System.Collections.Generic;
using MAPI.DATA;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MAPI.Controllers
{
    public class ApplicationDBContext:DbContext
    {
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    public DbSet<Userdetails> users { get; set; }

    public DbSet<TicketFair> tickect { get; set; }
    public DbSet<TravelDetails> travel { get; set; }
        
    }
}