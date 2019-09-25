namespace WebAPIDemo.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPIDemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAPIDemoContext context)
        {
            context.Categories.AddOrUpdate(x => x.Id,
               new Category { Id = 1, Name = "Mobile" },
               new Category { Id = 2, Name = "Tablet" },
               new Category { Id = 3, Name = "Smart watch" }
               );

            context.Products.AddOrUpdate(x => x.Id,
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    CategoryId = 1,
                    Price = 9.99M,
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    CategoryId = 1,
                    Price = 12.95M,
                },
                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    CategoryId = 2,
                    Price = 15,
                },
                new Product
                {
                    Id = 4,
                    Name = "Product 4",
                    CategoryId = 3,
                    Price = 10,
                }

                );
        }
    }
}
