using CodeAcademy.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.TaskManagement.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();

        Customer GetById(int id);

        bool Create(Customer customer);

        bool Update(Customer customer);

        bool Delete(int id);
    }
}
