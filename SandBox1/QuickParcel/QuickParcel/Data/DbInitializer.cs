using QuickParcel.Models;
using System;
using System.Linq;

namespace QuickParcel.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureCreated();
            // look for any customers
            if (context.Customers.Any())
            {
                return; //Db has been seeded
            }
            //START _Customers Seeding to Db
            var Customers = new Customer[]
            {
               new Customer { FirstName = "John", LastName = "Doe" },
               new Customer { FirstName = "Jane", LastName = "Smith" },
               new Customer { FirstName = "Michael", LastName = "Johnson" },
               new Customer { FirstName = "Emily", LastName = "Williams" },
               new Customer { FirstName = "David", LastName = "Brown" },
               new Customer { FirstName = "Sarah", LastName = "Jones" },
               new Customer { FirstName = "Christopher", LastName = "Garcia" },
               new Customer { FirstName = "Jessica", LastName = "Martinez" },
               new Customer { FirstName = "Matthew", LastName = "Hernandez" },
               new Customer { FirstName = "Amanda", LastName = "Lopez" },
               new Customer { FirstName = "Daniel", LastName = "Gonzalez" },
               new Customer { FirstName = "Ashley", LastName = "Perez" }

            };
            foreach (Customer c in Customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();
            //END _Customers Seeding to Db

            //START_ Products seeding to Db
            var Products = new Product[]
            {
                 new Product { ProductID = 1050, ProductName = "Apple", ProductPrice = 2.5 },
                 new Product { ProductID = 4022, ProductName = "Orange", ProductPrice = 1.8 },
                 new Product { ProductID = 4041, ProductName = "Banana", ProductPrice = 1.2 },
                 new Product { ProductID = 1045, ProductName = "Grapes", ProductPrice = 3.5 },
                 new Product { ProductID = 3141, ProductName = "Pineapple", ProductPrice =  4.0 },
                 new Product { ProductID = 2021, ProductName = "Watermelon", ProductPrice =   5.5 },
                 new Product { ProductID = 2042, ProductName = "Strawberry", ProductPrice = 6.0 }

            };
            foreach (Product p in Products)
            {
                context.Products.Add(p);
            };
            context.SaveChanges();
            //END_ Products seeding to Db

            //START _Orders seeding to Db
            var Orders = new Order[]
            {
                new Order{CustomerID=1, ProductID=1050},
                new Order{CustomerID=1, ProductID=4022},
                new Order{CustomerID=1, ProductID=4041},
                new Order{CustomerID=2, ProductID=1045},
                new Order{CustomerID=2, ProductID=3141},
                new Order{CustomerID=2, ProductID=2021},
                new Order{CustomerID=3, ProductID=1050},
                new Order{CustomerID=4, ProductID=1050},
                new Order{CustomerID=4, ProductID=4022},
                new Order{CustomerID=5, ProductID=4041},
                new Order{CustomerID=6, ProductID=1045},
                new Order{CustomerID=7, ProductID=3141},
            };
            foreach (Order o in Orders)
            {
                context.Orders.Add(o);
            };
            context.SaveChanges();
            //END _Orders seeding to Db
        }
    }
}


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               