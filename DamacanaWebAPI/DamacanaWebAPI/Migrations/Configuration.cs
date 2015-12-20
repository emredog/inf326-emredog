namespace DamacanaWebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DamacanaWebAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DamacanaWebAPI.Models.DamacanaWebAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DamacanaWebAPI.Models.DamacanaWebAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            // Seed some users
            context.Users.AddOrUpdate(x => x.Id,
                new User() { Id = Guid.Parse("23971e6c-c21f-4a78-a780-c3ee515599d1"), Name = "Emre", Surname = "Dogan", Address = "Tesvikiye" },
                new User() { Id = Guid.Parse("94af46f9-5ce9-42e1-a76b-001786dc03a3"), Name = "Gonen", Surname = "Eren", Address = "Ortakoy" },
                new User() { Id = Guid.Parse("f36dd678-ca45-4c8b-8701-44a6830daf82"), Name = "Ozan", Surname = "Caglayan", Address = "Goztepe" });

            // Seed some products
            context.Products.AddOrUpdate(x => x.Id,
                new Product() { Id = Guid.Parse("3c8ce659-4f66-4c4e-a590-81f9c17319ba"), Name = "Pinar", Price = (Decimal)10.0 },
                new Product() { Id = Guid.Parse("ac06ad34-1df7-4793-85c3-452fa60f80b9"), Name = "Erikli", Price = (Decimal)11.0 },
                new Product() { Id = Guid.Parse("49a2ffaa-75e4-42e2-aa43-bc060c241787"), Name = "Nestle", Price = (Decimal)10.0 },
                new Product() { Id = Guid.Parse("76f0bb03-631e-4caa-a9cb-2004b1dda0d6"), Name = "Hamidiye", Price = (Decimal)8.0 },
                new Product() { Id = Guid.Parse("f20a7a1c-abfd-45c7-8967-f30fbc8682d6"), Name = "Hayat", Price = (Decimal)11.0 });

            // Seed some purchase history
            //context.Purchases.AddOrUpdate(x => x.Id,
            //    new Purchase() { I})

        }
    }
}
