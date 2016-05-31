namespace CodeAcademy.Airports.RepositoryEF.Migrations
{
    using Domain.Entities;
    using Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeAcademy.Airports.RepositoryEF.Database>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CodeAcademy.Airports.RepositoryEF.Database";
        }

        //GenericRepository<Airport> _airportRepository = new GenericRepository<Airport>();
        //GenericRepository<BusinessObject> _businessObjectRepository = new GenericRepository<BusinessObject>();
        //GenericRepository<Employee> _employeeRepository = new GenericRepository<Employee>();


        protected override void Seed(CodeAcademy.Airports.RepositoryEF.Database context)
        {
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.

            context.Airports.AddOrUpdate(
                a => a.Code,
                new Airport { Address = "Address 1", City = "Skopje", Code = "SKP", Country = "Macedonia", Hotline = "123-123-123" },
                new Airport { Address = "Address 2", City = "Ohrid", Code = "OHD", Country = "Macedonia", Hotline = "456-456-456" },
                new Airport { Address = "Address 3", City = "Belgrade", Code = "BGD", Country = "Serbia", Hotline = "147-147-147" }
            );

            context.SaveChanges();

            context.BusinessObjects.AddOrUpdate(o => o.Name,
                   new BusinessObject
                   {
                       Name = "Business Object 1",
                       Airport = context.Airports.SingleOrDefault(a => a.Code.Equals("SKP")),
                       Type = BusinessObjectType.CoffeeBar,
                       OpeningTime = new TimeSpan(6,0,0),
                       ClosingTime = new TimeSpan(22,0,0)
                   },
                   new BusinessObject
                   {
                       Name = "Business Object 2",
                       Airport = context.Airports.SingleOrDefault(a => a.Code.Equals("SKP")),
                       Type = BusinessObjectType.DutyFreeCenter,
                       OpeningTime = new TimeSpan(8, 0, 0),
                       ClosingTime = new TimeSpan(20, 0, 0)
                   },
                   new BusinessObject
                   {
                       Name = "Business Object 3",
                       Airport = context.Airports.SingleOrDefault(a => a.Code.Equals("SKP")),
                       Type = BusinessObjectType.GiftStore,
                       OpeningTime = new TimeSpan(7, 0, 0),
                       ClosingTime = new TimeSpan(21, 0, 0)
                   },
                   new BusinessObject
                   {
                       Name = "Business Object 4",
                       Airport = context.Airports.SingleOrDefault(a => a.Code.Equals("OHD")),
                       Type = BusinessObjectType.Other,
                       OpeningTime = new TimeSpan(6, 30, 0),
                       ClosingTime = new TimeSpan(21, 30, 0)
                   },
                   new BusinessObject
                   {
                       Name = "Business Object 5",
                       Airport = context.Airports.SingleOrDefault(a => a.Code.Equals("OHD")),
                       Type = BusinessObjectType.CoffeeBar,
                       OpeningTime = new TimeSpan(6, 0, 0),
                       ClosingTime = new TimeSpan(10, 0, 0)
                   },
                   new BusinessObject
                   {
                       Name = "Business Object 6",
                       Airport = context.Airports.SingleOrDefault(a => a.Code.Equals("OHD")),
                       Type = BusinessObjectType.ShoppingPlace,
                       OpeningTime = new TimeSpan(8, 30, 0),
                       ClosingTime = new TimeSpan(20, 30, 0)
                   },
                   new BusinessObject
                   {
                       Name = "Business Object 7",
                       Airport = context.Airports.SingleOrDefault(a => a.Code.Equals("BGD")),
                       Type = BusinessObjectType.SleepingChambers,
                       OpeningTime = new TimeSpan(5, 0, 0),
                       ClosingTime = new TimeSpan(0, 0, 0)
                   },
                   new BusinessObject
                   {
                       Name = "Business Object 8",
                       Airport = context.Airports.SingleOrDefault(a => a.Code.Equals("BGD")),
                       Type = BusinessObjectType.Terminals,
                       OpeningTime = new TimeSpan(5, 0, 0),
                       ClosingTime = new TimeSpan(0, 0, 0)
                   },
                   new BusinessObject
                   {
                       Name = "Business Object 9",
                       Airport = context.Airports.SingleOrDefault(a => a.Code.Equals("BGD")),
                       Type = BusinessObjectType.WorkPlace,
                       OpeningTime = new TimeSpan(6, 30, 0),
                       ClosingTime = new TimeSpan(22, 30, 0)
                   }
               );

            context.SaveChanges();

            context.Employees.AddOrUpdate(e => e.Email,
                new Employee { Email = "petko@gmail.com", Name = "Petko", Password = "123", ResponsibleFor = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 1")) },
                new Employee { Email = "trajko@gmail.com", Name = "Trajko", Password = "123", ResponsibleFor = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 1")) },
                new Employee { Email = "cvetko@gmail.com", Name = "Cvetko", Password = "123", ResponsibleFor = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 2")) },
                new Employee { Email = "mitra@gmail.com", Name = "Mitra", Password = "123", ResponsibleFor = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 2")) },
                new Employee { Email = "stojna@gmail.com", Name = "Stojna", Password = "123", ResponsibleFor = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 3")) },
                new Employee { Email = "micko@gmail.com", Name = "Micko", Password = "123", ResponsibleFor = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 4")) },
                new Employee { Email = "velko@gmail.com", Name = "Velko", Password = "123", ResponsibleFor = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 5")) },
                new Employee { Email = "trpa@gmail.com", Name = "Trpa", Password = "123", ResponsibleFor = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 6")) },
                new Employee { Email = "cveta@gmail.com", Name = "Cveta", Password = "123", ResponsibleFor = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 7")) },
                new Employee { Email = "vera@gmail.com", Name = "Vera", Password = "123", ResponsibleFor = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 8")) },
                new Employee { Email = "pavle@gmail.com", Name = "Pavle", Password = "123", ResponsibleFor = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 9")) }
                );

            context.SaveChanges();

            context.Offers.AddOrUpdate(o => o.Title,
                new Offer { Title = "Offer 1", AvailableQuantity = 100, DiscountPercentages = 10, IsAttractive = true, Price = 100, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 1")) },
                new Offer { Title = "Offer 2", AvailableQuantity = 50, DiscountPercentages = 0, IsAttractive = false, Price = 50, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 1")) },
                new Offer { Title = "Offer 3", AvailableQuantity = 200, DiscountPercentages = 20, IsAttractive = true, Price = 150, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 2")) },
                new Offer { Title = "Offer 4", AvailableQuantity = 300, DiscountPercentages = 0, IsAttractive = false, Price = 200, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 2")) },
                new Offer { Title = "Offer 5", AvailableQuantity = 150, DiscountPercentages = 15, IsAttractive = true, Price = 250, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 3")) },
                new Offer { Title = "Offer 6", AvailableQuantity = 190, DiscountPercentages = 0, IsAttractive = false, Price = 80, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 3")) },
                new Offer { Title = "Offer 7", AvailableQuantity = 40, DiscountPercentages = 25, IsAttractive = true, Price = 180, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 4")) },
                new Offer { Title = "Offer 8", AvailableQuantity = 20, DiscountPercentages = 0, IsAttractive = false, Price = 230, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 4")) },
                new Offer { Title = "Offer 9", AvailableQuantity = 80, DiscountPercentages = 30, IsAttractive = true, Price = 190, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 5")) },
                new Offer { Title = "Offer 10", AvailableQuantity = 600, DiscountPercentages = 0, IsAttractive = false, Price = 230, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 5")) },
                new Offer { Title = "Offer 11", AvailableQuantity = 400, DiscountPercentages = 35, IsAttractive = true, Price = 300, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 6")) },
                new Offer { Title = "Offer 12", AvailableQuantity = 40, DiscountPercentages = 0, IsAttractive = false, Price = 70, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 6")) },
                new Offer { Title = "Offer 13", AvailableQuantity = 60, DiscountPercentages = 40, IsAttractive = true, Price = 400, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 7")) },
                new Offer { Title = "Offer 14", AvailableQuantity = 90, DiscountPercentages = 0, IsAttractive = false, Price = 120, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 7")) },
                new Offer { Title = "Offer 15", AvailableQuantity = 62, DiscountPercentages = 10, IsAttractive = true, Price = 320, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 8")) },
                new Offer { Title = "Offer 16", AvailableQuantity = 101, DiscountPercentages = 0, IsAttractive = false, Price = 841, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 8")) },
                new Offer { Title = "Offer 17", AvailableQuantity = 98, DiscountPercentages = 50, IsAttractive = true, Price = 329, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 9")) },
                new Offer { Title = "Offer 18", AvailableQuantity = 32, DiscountPercentages = 0, IsAttractive = true, Price = 287, BusinessObject = context.BusinessObjects.SingleOrDefault(o => o.Name.Equals("Business Object 9")) }

                );

        }
    }
}
