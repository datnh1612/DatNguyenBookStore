namespace BookStoreData.Migrations
{
    using BookStoreModel.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStoreData.DatNguyenBookStoreDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookStoreData.DatNguyenBookStoreDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //  Create data for example

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DatNguyenBookStoreDBContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new DatNguyenBookStoreDBContext()));

            var user1 = new ApplicationUser()
            {
                UserName = "Superman",
                Email = "datnh1612@gmail.com.vn",
                EmailConfirmed = true,
                Birthday = DateTime.Now,
                FullName = "Nguyen Huu Dat"
            };
            manager.Create(user1, "123456@");

            // if does'nt exist any role in database, we will create 2 role for example
            if(!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            // Set role admin for new user

            var adminUser = manager.FindByEmail("datnh1612@gmail.com.vn");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}
