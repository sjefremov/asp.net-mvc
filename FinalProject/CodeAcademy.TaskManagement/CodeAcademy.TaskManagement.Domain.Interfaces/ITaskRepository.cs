using CodeAcademy.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeAcademy.TaskManagement.Domain.Interfaces
{
    public interface ITaskRepository
    {
        List<Task> GetAll();
        Task GetById(int id);
        List<Task> GetByProject(int projectId);

        bool Create(Task task);
        bool Update(Task task);
        bool Delete(int id);

        List<TaskComment> GetComments(int taskId);
        string GetAssigneeName(int taskId);
    }
}
