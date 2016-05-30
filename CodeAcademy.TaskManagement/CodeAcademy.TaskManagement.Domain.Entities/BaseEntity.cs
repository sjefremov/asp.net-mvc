using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.TaskManagement.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int ID { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual DateTime DateCreated { get; set; }
    }
}
