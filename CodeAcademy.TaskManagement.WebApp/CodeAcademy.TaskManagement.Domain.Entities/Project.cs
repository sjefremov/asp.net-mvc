using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.TaskManagement.Domain.Entities
{
    public class Project
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual int CustomerId { get; set; }
    }
}
