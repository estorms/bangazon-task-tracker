using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bangazon_Task_Tracker.Models
{
    public class UserTask
    {
        [Key]
        public  int UserTaskId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public enum TaskStatus { ToDo, InProgress, Complete }

        [Required]
        public TaskStatus Status { get; set; }

        public DateTime CompletedOn { get; set; }
    }
}
