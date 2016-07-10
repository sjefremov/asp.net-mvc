namespace CodeAcademy.TaskManagement.RepositoryEF.Migrations
{
    using Domain.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeAcademy.TaskManagement.RepositoryEF.Database>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CodeAcademy.TaskManagement.RepositoryEF.Database";
        }

        protected override void Seed(RepositoryEF.Database context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            
            CreateTwoUsersIfNotExists(context);

            context.Customers.AddOrUpdate(
              c => c.Email,
              new Customer { Company = "Trajko's", DateCreated = DateTime.Now, Email = "trajko@gmail.com", IsActive = true,
                  Name = "Trajko" },
              new Customer { Company = "Petko's", DateCreated = DateTime.Now, Email = "petko@gmail.com", IsActive = true,
                  Name = "Petko" }
            );
            context.SaveChanges();

            context.Projects.AddOrUpdate(p => p.Name,
                new Project { Customer = context.Customers.SingleOrDefault(c => c.Email.Equals("trajko@gmail.com")),
                    DateCreated = DateTime.Now, IsActive = true, Name = "Trajko's first project" },
                new Project { Customer = context.Customers.SingleOrDefault(c => c.Email.Equals("petko@gmail.com")),
                    DateCreated = DateTime.Now, IsActive = true, Name = "Petko's first project" }
            );
            context.SaveChanges();

            context.Tasks.AddOrUpdate(t => t.Name,
                new Task { DateCreated = DateTime.Now, Description = "Some description", EndDate = new DateTime(2016, 9, 1),
                    EstimatedHours = 100, IsActive = true, Name = "Task 1",
                    Project = context.Projects.SingleOrDefault(p => p.Name.Equals("Trajko's first project")),
                    StartDate = new DateTime(2016, 7, 7), Status = TaskStatus.ToDo, Type = TaskType.Task,
                    User = context.Users.SingleOrDefault(u => u.Email.Equals("Student@gmail.com")) },
                new Task
                {
                    DateCreated = DateTime.Now,
                    Description = "Some description",
                    EndDate = new DateTime(2016, 11, 1),
                    EstimatedHours = 200,
                    IsActive = true,
                    Name = "Task 2",
                    Project = context.Projects.SingleOrDefault(p => p.Name.Equals("Trajko's first project")),
                    StartDate = new DateTime(2016, 6, 7),
                    Status = TaskStatus.InProgress,
                    Type = TaskType.Bug,
                    User = context.Users.SingleOrDefault(u => u.Email.Equals("Admin@gmail.com"))
                },
                new Task
                {
                    DateCreated = DateTime.Now,
                    Description = "Some description",
                    EndDate = new DateTime(2016, 10, 1),
                    EstimatedHours = 300,
                    IsActive = true,
                    Name = "Task 3",
                    Project = context.Projects.SingleOrDefault(p => p.Name.Equals("Trajko's first project")),
                    StartDate = new DateTime(2016, 5, 7),
                    Status = TaskStatus.Done,
                    Type = TaskType.SupportRequest,
                    User = context.Users.SingleOrDefault(u => u.Email.Equals("Student@gmail.com"))
                },
                new Task
                {
                    DateCreated = DateTime.Now,
                    Description = "Some description",
                    EndDate = new DateTime(2016, 9, 1),
                    EstimatedHours = 150,
                    IsActive = true,
                    Name = "Task 4",
                    Project = context.Projects.SingleOrDefault(p => p.Name.Equals("Trajko's first project")),
                    StartDate = new DateTime(2016, 7, 7),
                    Status = TaskStatus.InTesting,
                    Type = TaskType.Task,
                    User = context.Users.SingleOrDefault(u => u.Email.Equals("Student@gmail.com"))
                },
                new Task
                {
                    DateCreated = DateTime.Now,
                    Description = "Some description",
                    EndDate = new DateTime(2016, 9, 1),
                    EstimatedHours = 100,
                    IsActive = true,
                    Name = "Task 5",
                    Project = context.Projects.SingleOrDefault(p => p.Name.Equals("Petko's first project")),
                    StartDate = new DateTime(2016, 7, 7),
                    Status = TaskStatus.ToDo,
                    Type = TaskType.Task,
                    User = context.Users.SingleOrDefault(u => u.Email.Equals("Student@gmail.com"))
                },
                new Task
                {
                    DateCreated = DateTime.Now,
                    Description = "Some description",
                    EndDate = new DateTime(2016, 11, 1),
                    EstimatedHours = 200,
                    IsActive = true,
                    Name = "Task 6",
                    Project = context.Projects.SingleOrDefault(p => p.Name.Equals("Petko's first project")),
                    StartDate = new DateTime(2016, 6, 7),
                    Status = TaskStatus.InProgress,
                    Type = TaskType.Bug,
                    User = context.Users.SingleOrDefault(u => u.Email.Equals("Admin@gmail.com"))
                },
                new Task
                {
                    DateCreated = DateTime.Now,
                    Description = "Some description",
                    EndDate = new DateTime(2016, 10, 1),
                    EstimatedHours = 300,
                    IsActive = true,
                    Name = "Task 7",
                    Project = context.Projects.SingleOrDefault(p => p.Name.Equals("Petko's first project")),
                    StartDate = new DateTime(2016, 5, 7),
                    Status = TaskStatus.Done,
                    Type = TaskType.SupportRequest,
                    User = context.Users.SingleOrDefault(u => u.Email.Equals("Student@gmail.com"))
                },
                new Task
                {
                    DateCreated = DateTime.Now,
                    Description = "Some description",
                    EndDate = new DateTime(2016, 9, 1),
                    EstimatedHours = 150,
                    IsActive = true,
                    Name = "Task 8",
                    Project = context.Projects.SingleOrDefault(p => p.Name.Equals("Petko's first project")),
                    StartDate = new DateTime(2016, 7, 7),
                    Status = TaskStatus.InTesting,
                    Type = TaskType.Task,
                    User = context.Users.SingleOrDefault(u => u.Email.Equals("Student@gmail.com"))
                }
            );
            context.SaveChanges();


            //
        }
        /// <summary>
        /// creates Admin (Admin@gmail.com) user and Student(Student@gmail.com) user if they do not exist
        /// </summary>
        /// <param name="context"></param>
        private void CreateTwoUsersIfNotExists(RepositoryEF.Database context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string adminName = "Admin";
            string adminEmail = adminName + "@gmail.com";
            string adminPassword = "Password1!";

            if (!roleManager.RoleExists(adminName))
            {
                roleManager.Create(new IdentityRole(adminName));
            }
            
            var adminUser = new User();
            adminUser.UserName = adminEmail;
            adminUser.IsActive = true;
            adminUser.PendingApproval = false;
            adminUser.DateCreated = DateTime.Now;
            adminUser.DisplayName = adminName;
            adminUser.Email = adminEmail;

            var adminResult = userManager.Create(adminUser, adminPassword);

            if (adminResult.Succeeded)
            {
                userManager.AddToRole(adminUser.Id, adminName);
            }

            string userName = "Student";
            string userEmail = userName + "@gmail.com";
            string userPassword = "Password1!";

            var user = new User();
            user.UserName = userEmail;
            user.IsActive = true;
            user.PendingApproval = false;
            user.DateCreated = DateTime.Now;
            user.DisplayName = userName;
            user.Email = userEmail;

            userManager.Create(user, userPassword);
        }
    }
}
