using CodeAcademy.TaskManagement.Domain.Entities;
using CodeAcademy.TaskManagement.Domain.Interfaces;
using CodeAcademy.TaskManagement.RepositoryEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeAcademy.TaskManagement.WebApp.Models
{
    public class ProjectViewModel
    {
        static ICustomerRepository _customerRepository = new CustomerRepository();

        public int ID { get; set; }

        public string Name { get; set; }

        public string Customer { get; set; }

        public string DateCreated { get; set; }

        public static ProjectViewModel FromModel(Project project)
        {
            return new ProjectViewModel
            {
                ID = project.ID,
                Name = project.Name,
                Customer = project.Customer == null ? _customerRepository.GetById(project.CustomerId).Name : project.Customer.Name,
                DateCreated = project.DateCreated.ToString("dd.MM.yyyy hh:mm:ss")
            };
        }
    }
}