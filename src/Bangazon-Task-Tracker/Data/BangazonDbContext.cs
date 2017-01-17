using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon_Task_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Bangazon_Task_Tracker.Data
{
    public class BangazonDbContext: DbContext
    {
        public DbSet<UserTask> UserTask { get; set; }

    public BangazonDbContext(DbContextOptions<BangazonDbContext> options)
            : base(options)
        { }
    }

}

