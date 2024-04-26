using QuickParcelApi.Models;

namespace QuickParcelApi.Data
{
    public static class QuickParcelInitializer
    {
        public static void Initialize(QuickParcelDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category{CategoryName = "Mobiles"},
                new Category{CategoryName = "TVs"},
                new Category{CategoryName = "Cameras"},
                new Category{CategoryName = "Laptops"},
            };

            foreach (var category in categories) { context.Categories.Add(category); }
            context.SaveChanges();

            var products = new Product[]
            {
                new Product{ProductName = "LG Smart TV", UnitPrice = decimal.Parse("16000"), CategoryID = categories.Single(c => c.CategoryName == "TVs").CategoryID},
                new Product{ProductName = "Samsung Galaxy S20", UnitPrice = decimal.Parse("800"), CategoryID = categories.Single(c => c.CategoryName == "Mobiles").CategoryID},
                new Product{ProductName = "Canon EOS 80D", UnitPrice = decimal.Parse("1200"), CategoryID = categories.Single(c => c.CategoryName == "Cameras").CategoryID},
                new Product{ProductName = "MacBook Pro", UnitPrice = decimal.Parse("2000"), CategoryID = categories.Single(c => c.CategoryName == "Laptops").CategoryID},
                new Product{ProductName = "Sony PlayStation 5", UnitPrice = decimal.Parse("500"), CategoryID = categories.Single(c => c.CategoryName == "Consoles").CategoryID},
                new Product{ProductName = "Apple Watch Series 6", UnitPrice = decimal.Parse("400"), CategoryID = categories.Single(c => c.CategoryName == "Wearables").CategoryID},
                new Product{ProductName = "Dell XPS 15", UnitPrice = decimal.Parse("1500"), CategoryID = categories.Single(c => c.CategoryName == "Laptops").CategoryID},
                new Product{ProductName = "GoPro Hero 9 Black", UnitPrice = decimal.Parse("450"), CategoryID = categories.Single(c => c.CategoryName == "Cameras").CategoryID},
            };
        }

    }
}