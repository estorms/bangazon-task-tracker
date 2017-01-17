using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bangazon_Task_Tracker.Data;
using Bangazon_Task_Tracker.Models;

namespace Bangazon_Task_Tracker.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserTaskController : Controller
    {

        private BangazonDbContext context;

        public UserTaskController(BangazonDbContext ctx)
        {
            context = ctx;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> UserTasks = from userTask in context.UserTask select userTask;

            if (UserTasks == null)
            {
                return NotFound();
            }

            return Ok(UserTasks);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
