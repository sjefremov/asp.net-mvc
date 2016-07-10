using CodeAcademy.TaskManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAcademy.TaskManagement.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace CodeAcademy.TaskManagement.RepositoryEF.Repositories
{
    public class UserRepository : IUserRepository
    {
        
        Database db = new Database();
        

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return db.Users
                        .Where(u => u.IsActive && !u.PendingApproval)
                        .OrderByDescending(u => u.DateCreated)
                        .ToList();
        }
        
        public bool Update(User user)
        {
            var dbUser = GetById(user.Id);

            if (dbUser == null)
            {
                return false;
            }

            dbUser.PendingApproval = user.PendingApproval;
            db.SaveChanges();

            return true;
        }

        public User GetById(string id)
        {
            return GetAll().SingleOrDefault(u => u.Id.Equals(id));
        }

        public User GetByEmail(string email)
        {
            return GetAll().SingleOrDefault(u => u.Email.Equals(email));
        }
    }
}
