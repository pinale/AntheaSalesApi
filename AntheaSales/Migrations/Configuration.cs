namespace AntheaSales.Migrations
{
    using AntheaSales.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AntheaSales.Models.SalesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AntheaSales.Models.SalesDbContext";
        }

        protected override void Seed(SalesDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //LOCAL DB INSTANCE
            //(localdb)\MSSQLLocalDB
            //https://docs.microsoft.com/it-it/ef/ef6/modeling/code-first/workflows/new-database

            context.OrderItems.RemoveRange(context.OrderItems.ToList());
            context.Orders.RemoveRange(context.Orders.ToList());
            context.Products.RemoveRange(context.Products.ToList());
            context.Categories.RemoveRange(context.Categories.ToList());
            context.SaveChanges();



            var booksCat = new Category() { Description = "Books", SalesTax = 0d };
            var foodCat = new Category() { Description = "Food", SalesTax = 0d };
            var medicalCat = new Category() { Description = "Medical", SalesTax = 0d };
            var musicCat = new Category() { Description = "Music", SalesTax = 10d };
            var cosmeticsCat = new Category() { Description = "Cosmetics", SalesTax = 10d };
            var veichlesCat = new Category() { Description = "Vehicles", SalesTax = 10d };
            var technologyCat = new Category() { Description = "Technology", SalesTax = 10d };

            context.Categories.AddOrUpdate(x => x.Description, booksCat);
            context.Categories.AddOrUpdate(x => x.Description, foodCat);
            context.Categories.AddOrUpdate(x => x.Description, musicCat);
            context.Categories.AddOrUpdate(x => x.Description, cosmeticsCat);
            context.Categories.AddOrUpdate(x => x.Description, veichlesCat);
            context.Categories.AddOrUpdate(x => x.Description, technologyCat);


            var bookProd = new Product() { Description = "book", Price = 12.49, Category = booksCat };
            var musicCdProd = new Product() { Description = "music CD", Price = 14.99, Category = musicCat };
            var chocoloareBarProd = new Product() { Description = "chocolate bar", Price = 0.85,  Category = foodCat };
            var boxOfChocolateAProd = new Product() { Description = "box of chocolate A", Price = 10.00, ImportTaxRate = 5, Category = foodCat };
            var boxOfChocolateBProd = new Product() { Description = "box of chocolate B", Price = 11.25, ImportTaxRate = 5, Category = foodCat };
            var bottleOfPerfumeAProd = new Product() { Description = "bottle of perfume A", Price = 47.50, ImportTaxRate = 5, Category = cosmeticsCat };
            var bottleOfPerfumeBProd = new Product() { Description = "bottle of perfume B", Price = 27.99, ImportTaxRate = 5, Category = cosmeticsCat };
            var bottleOfPerfumeCProd = new Product() { Description = "bottle of perfume C", Price = 18.99, Category = cosmeticsCat };
            var headachePillsProd = new Product() { Description = "headache pills (packet)", Price = 9.75, Category = medicalCat };


            context.Products.AddOrUpdate(x => x.Description, bookProd);
            context.Products.AddOrUpdate(x => x.Description, musicCdProd);
            context.Products.AddOrUpdate(x => x.Description, chocoloareBarProd);
            context.Products.AddOrUpdate(x => x.Description, boxOfChocolateAProd);
            context.Products.AddOrUpdate(x => x.Description, boxOfChocolateBProd);
            context.Products.AddOrUpdate(x => x.Description, bottleOfPerfumeAProd);
            context.Products.AddOrUpdate(x => x.Description, bottleOfPerfumeBProd);
            context.Products.AddOrUpdate(x => x.Description, bottleOfPerfumeCProd);
            context.Products.AddOrUpdate(x => x.Description, headachePillsProd);


            var orderItem1_1 = new OrderItem() { Product = bookProd, Quantity = 2 };
            var orderItem2_1 = new OrderItem() { Product = musicCdProd, Quantity = 1 };
            var orderItem3_1 = new OrderItem() { Product = chocoloareBarProd, Quantity = 1 };
            var order1 = new Order() { OrderDescription="Order 1", Date = new DateTime(2019, 01, 10), Items = new List<OrderItem> { orderItem1_1, orderItem2_1, orderItem3_1 } };

            var orderItem1_2 = new OrderItem() { Product = boxOfChocolateAProd, Quantity = 1 };
            var orderItem2_2 = new OrderItem() { Product = bottleOfPerfumeAProd, Quantity = 1 };
            var order2 = new Order() { OrderDescription = "Order 2", Date = new DateTime(2019, 02, 20), Items = new List<OrderItem> { orderItem1_2, orderItem2_2, } };

            var orderItem1_3 = new OrderItem() { Product = bottleOfPerfumeBProd, Quantity = 1 };
            var orderItem2_3 = new OrderItem() { Product = bottleOfPerfumeCProd, Quantity = 1 };
            var orderItem3_3 = new OrderItem() { Product = headachePillsProd, Quantity = 1 };
            var orderItem4_3 = new OrderItem() { Product = boxOfChocolateBProd, Quantity = 3 };
            var order3 = new Order() { OrderDescription = "Order 3", Date = new DateTime(2019, 03, 5), Items = new List<OrderItem> { orderItem1_3, orderItem2_3, orderItem3_3, orderItem4_3 } };

            context.Orders.AddOrUpdate(order1);
            context.Orders.AddOrUpdate(order2);
            context.Orders.AddOrUpdate(order3);
            

            context.SaveChanges();
        }
    }
}
