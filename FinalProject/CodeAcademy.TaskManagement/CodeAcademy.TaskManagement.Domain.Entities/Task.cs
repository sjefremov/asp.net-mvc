using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeAcademy.TaskManagement.Domain.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Estimated hours")]
        public int EstimatedHours { get; set; }

        [Display(Name = "Start date")]
        [DataType(DataType.Date, ErrorMessage = "Must be valid date!")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End date")]
        [DataType(DataType.Date, ErrorMessage = "Must be valid date!")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        //[JsonConverter(typeof(StringEnumConverter))]
        public TaskType Type { get; set; }

        //[JsonConverter(typeof(StringEnumConverter))]
        public TaskStatus Status { get; set; }

        public virtual ICollection<TaskComment> Comments { get; set; }

        public virtual int ProjectId { get; set; } //this is foreign key
        public virtual Project Project { get; set; }

        public virtual string UserId { get; set; }
        public virtual User User { get; set; }
    }

    public enum TaskType
    {
        Task = 0,
        Bug = 1,
        ChangeRequest = 2,
        SupportRequest = 3
        //Task, Bug, ChangeRequest, SupportRequest
    }

    public enum TaskStatus
    {
        ToDo = 0,
        InProgress = 1,
        InTesting = 2,
        Done = 3
    }
}
