using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bangazon_Task_Tracker.Models;

namespace Bangazon_Task_Tracker.Data
{
    public class DbInitializer
    {
        //Method: The initialize method creates a scoped variable "context," which represents a session with the database. If there are any products currently in the database, then it will not be seeded.
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BangazonDbContext(serviceProvider.GetRequiredService<DbContextOptions<BangazonDbContext>>()))
            {
          
                if (context.UserTask.Any())
                    {
                        return;
                    }

                var userTasksArr = new UserTask[]
                {
                  new UserTask {
                      Name = "Design New Logo",
                      Description = "Something with cats, please.",
                      Status = 0
                  },
                  new UserTask {
                      Name = "Update Product Catalogue",
                      Description = "We now sell cat toys and small appliances",
                      Status = 0
                  },
                  new UserTask {
                      Name = "Hire At Least 43 New Developers",
                      Description = "This one's urgent",
                      Status = 0
                  }
                };

                foreach (UserTask u in userTasksArr)
                {
                    context.UserTask.Add(u);
                }
                context.SaveChanges();



            }
        }
    }
}
