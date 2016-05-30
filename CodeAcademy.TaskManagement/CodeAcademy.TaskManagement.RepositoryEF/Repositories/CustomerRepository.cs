using CodeAcademy.TaskManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAcademy.TaskManagement.Domain.Entities;

namespace CodeAcademy.TaskManagement.RepositoryEF.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        Database db = new Database();
        public bool Create(Customer customer)
        {
            customer.DateCreated = DateTime.Now;
            customer.IsActive = true;

            db.Customers.Add(customer);
            db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            return db.Customers.Where(c => c.IsActive).ToList();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
