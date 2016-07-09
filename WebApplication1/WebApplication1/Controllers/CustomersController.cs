using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomersController : ApiController
    {
        public List<Customer> Get()
        {
            var customers = new List<Customer>
            {
                new Customer { ID = 1, Name = "Chuck Norris", Email = "norris@chuck.org", IsVip = true },
                new Customer { ID = 2, Name = "Bill Gates", Email = "bill@microsoft.com", IsVip = true },
                new Customer { ID = 3, Name = "Donald Trump", Email = "donald@trump.org", IsVip = false }
            };

            return customers;
        }
        [Route("/api/customers-by-name")]
        public List<Customer> GetOrderedByName()
        {
            var customers = new List<Customer>
            {
                new Customer { ID = 1, Name = "Chuck Norris", Email = "norris@chuck.org", IsVip = true },
                new Customer { ID = 2, Name = "Bill Gates", Email = "bill@microsoft.com", IsVip = true },
                new Customer { ID = 3, Name = "Donald Trump", Email = "donald@trump.org", IsVip = false }
            };

            return customers.OrderBy(c => c.Name).ToList();
        }

        public List<Customer> GetWhatever(int id)
        {
            var customers = new List<Customer>
            {
                new Customer { ID = 1, Name = "Chuck Norris", Email = "norris@chuck.org", IsVip = true },
                new Customer { ID = 2, Name = "Bill Gates", Email = "bill@microsoft.com", IsVip = true },
                new Customer { ID = 3, Name = "Donald Trump", Email = "donald@trump.org", IsVip = false }
            };

            return customers.Where(c => c.ID == id).ToList();
        }
        [Http]
        public void Post()
        {
            respo
        }

        public void Put()
        {

        }

        public void Delete()
        {

        }
    }
}
