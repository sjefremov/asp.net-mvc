﻿using CodeAcademy.TaskManagement.Domain.Interfaces;
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
            var dbCustomer = GetById(id);

            if (dbCustomer != null)
            {
                dbCustomer.IsActive = false;

                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Customer> GetAll()
        {
            return db.Customers.Where(c => c.IsActive).ToList();
        }

        public Customer GetById(int id)
        {
            return GetAll().FirstOrDefault(c => c.ID == id);
        }

        public bool Update(Customer customer)
        {
            var dbCustomer = GetById(customer.ID);

            if (dbCustomer != null)
            {
                dbCustomer.Name = customer.Name;
                dbCustomer.Company = customer.Company;
                dbCustomer.Email = customer.Email;

                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
