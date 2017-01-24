using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bangazon_Task_Tracker.Data;
using Bangazon_Task_Tracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Bangazon_Task_Tracker.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
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
            //Either method below, i.e., with or without explicit syntax, returns desired result
            IQueryable<object> UserTasks = context.UserTask;
            //IQueryable<object> UserTasks = from userTask in context.UserTask select userTask;

            if (UserTasks == null)
            {
                return NotFound();
            }

            return Ok(UserTasks);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetUserTask")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                UserTask userTask = context.UserTask.Single(u => u.UserTaskId == id);

                if (userTask == null)
                {
                    return NotFound();
                }

                return Ok(userTask);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        [HttpGet("ByStatus/{status}")]
        public IActionResult ByStatus(int status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                IQueryable<UserTask> userTasks = context.UserTask.Where(u => u.Status == (UserTask.TaskStatus)status);
                return Ok(userTasks);
            }

           catch  
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        //FromBody means from the body of the request
        public IActionResult Post([FromBody] UserTask userTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.UserTask.Add(userTask);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserTaskExists(userTask.UserTaskId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetUserTask", new { id = userTask.UserTaskId }, userTask);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserTask userTask)
        {
            //this method wasn't working until making an explicit association between the id in the annotation/method and userTask
            userTask.UserTaskId = id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (userTask == null)
            {
                return NotFound();
            }

            if (userTask.Status == UserTask.TaskStatus.Complete)
            {
                userTask.CompletedOn = DateTime.Now;
            }
            context.UserTask.Update(userTask);
            context.SaveChanges();

            return Ok(userTask);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                UserTask userTask = context.UserTask.Single(u => u.UserTaskId == id);
                if (userTask == null)
                {
                    return NotFound();
                }

                context.UserTask.Remove(userTask);
                context.SaveChanges();

                return Ok();
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }



        private bool UserTaskExists(int id)
        {
            return context.UserTask.Count(e => e.UserTaskId == id) > 0;
        }
    }
}