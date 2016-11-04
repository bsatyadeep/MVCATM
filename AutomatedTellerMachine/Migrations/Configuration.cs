using System.Linq;
using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AutomatedTellerMachine.Migrations
{
    using Services;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AutomatedTellerMachine.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "AutomatedTellerMachine.Models.ApplicationDbContext";
        }

        protected override void Seed(AutomatedTellerMachine.Models.ApplicationDbContext context)
        {
            var userstore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userstore);
            if (!context.Users.Any(t => t.UserName == "admin@atm.com"))
            {
                var user = new ApplicationUser { UserName = "admin@atm.com", Email = "admin@atm.com" };
                userManager.Create(user, "Gelhai_$65");
                var service = new ChekingAccountService(context);
                service.CreateCheckingAccount("Admin", "User", user.Id, 1000);

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Admin");
            }
            //context.Transactions.Add(new Transaction { Amount = 75, CheckingAccountId = 2 });
            //context.Transactions.Add(new Transaction { Amount = -25, CheckingAccountId = 2 });
            //context.Transactions.Add(new Transaction { Amount = 100000, CheckingAccountId = 2 });
            //context.Transactions.Add(new Transaction { Amount = 19.99m, CheckingAccountId = 2 });
            //context.Transactions.Add(new Transaction { Amount = 64.40m, CheckingAccountId = 3 });
            //context.Transactions.Add(new Transaction { Amount = 100, CheckingAccountId = 3 });
            //context.Transactions.Add(new Transaction { Amount = -300, CheckingAccountId = 3 });
            //context.Transactions.Add(new Transaction { Amount = 255.75m, CheckingAccountId = 3 });
            //context.Transactions.Add(new Transaction { Amount = 198, CheckingAccountId = 4 });
            //context.Transactions.Add(new Transaction { Amount = 2, CheckingAccountId = 4 });
            //context.Transactions.Add(new Transaction { Amount = 50, CheckingAccountId = 4 });
            //context.Transactions.Add(new Transaction { Amount = -1.50m, CheckingAccountId = 4 });
            //context.Transactions.Add(new Transaction { Amount = 6100, CheckingAccountId = 4 });
            //context.Transactions.Add(new Transaction { Amount = 164.84m, CheckingAccountId = 4 });
            //context.Transactions.Add(new Transaction { Amount = .01m, CheckingAccountId = 4 });
            //  This method will be called after migrating to the latest version.            
        }
    }
}
