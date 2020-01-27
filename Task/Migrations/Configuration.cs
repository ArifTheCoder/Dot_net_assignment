namespace Task.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Task.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Task.Data.TaskContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Task.Data.TaskContext context)
        {
            context.Customers.AddOrUpdate(x => x.Id,
                new Customer() {Cin = "001", Name = "Customer1" },
                new Customer() {Cin = "002", Name = "Customer2" },
                new Customer() {Cin = "003", Name = "Customer3" },
                new Customer() {Cin = "004", Name = "Customer4" },
                new Customer() {Cin = "005", Name = "Customer5" }
                );

            context.Events.AddOrUpdate(x => x.Id,
                new Events() {Content = "Event 1", CustomerId = 1, IsOpen = true, EventDateTime = DateTime.Now},
                new Events() {Content = "Event 2", CustomerId = 2, IsOpen = false, EventDateTime = DateTime.Now.AddDays(4.00) },
                new Events() {Content = "Event 3", CustomerId = 3, IsOpen = false, EventDateTime = DateTime.Now.AddDays(5.00) },
                new Events() {Content = "Event 4", CustomerId = 4, IsOpen = false, EventDateTime = DateTime.Now.AddDays(6.00) },
                new Events() {Content = "Event 5", CustomerId = 5, IsOpen = false, EventDateTime = DateTime.Now.AddDays(7.00)}
                );
        }
    }
}
