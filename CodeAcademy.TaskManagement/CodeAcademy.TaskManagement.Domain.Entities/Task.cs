using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.TaskManagement.Domain.Entities
{
    public class Task
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int EstimatedHours { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public TaskType Type { get; set; }

        public virtual ICollection<TaskComment> Comments { get; set; }

        public virtual Project Project { get; set; }

        public virtual int ProjectId { get; set; } //Foreign key, this property is not obligated and virtual is optional

        public virtual User User { get; set; }

        public virtual int UserId { get; set; } //Foreign key, this property is not obligated and virtual is optional

    }

    public enum TaskType
    {
        Task = 0,
        Bug = 1,
        ChangeRequest = 2,
        SupportRequest = 3
        //Task, Bug, ChangeRequest, SupportRequest
    }
}
