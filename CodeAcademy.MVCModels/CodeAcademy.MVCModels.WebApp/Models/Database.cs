using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.MVCModels.WebApp.Models
{
    public class Database
    {
        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    ID = 1,
                    Name = "Chocolate",
                    Description = "The best chocolate made in Struga.",
                    Price = 100,
                    Quantity = 7000
                },
                new Product
                {
                    ID = 2,
                    Name = "Cake",
                    Description = "The best cake made in Ohrid.",
                    Price = 500,
                    Quantity = 100
                },
                new Product
                {
                    ID = 3,
                    Name = "Rice",
                    Description = "The best rice made in Kocani.",
                    Price = 60,
                    Quantity = 70000
                },
                new Product
                {
                    ID = 4,
                    Name = "Apple",
                    Description = "The best apple made in Resen.",
                    Price = 30,
                    Quantity = 50000
                },
                new Product
                {
                    ID = 5,
                    Name = "Grapes",
                    Description = "The best grapes made in Kavadarci.",
                    Price = 25,
                    Quantity = 100000
                }
            };
            return products;
        }
    }
}
