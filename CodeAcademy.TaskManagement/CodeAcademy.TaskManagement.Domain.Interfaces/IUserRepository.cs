using CodeAcademy.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.TaskManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();

        User GetById(int id);

        bool Create(User user);

        bool Update(User user);

        bool Delete(int id);
    }
}
