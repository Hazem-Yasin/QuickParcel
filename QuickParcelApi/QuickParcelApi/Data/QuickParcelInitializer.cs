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
                new Product{ProductName = "Sony Digital Camera", UnitPrice = decimal.Parse("76000"), CategoryID = categories.Single(c => c.CategoryName == "Cameras").CategoryID},
                new Product{ProductName = "HP ProBook 4045", UnitPrice = decimal.Parse("11000"), CategoryID = categories.Single(c => c.CategoryName == "LapTops").CategoryID},
                new Product{ProductName = "IPhone 14", UnitPrice = decimal.Parse("80000"), CategoryID = categories.Single(c => c.CategoryName == "Mobiles").CategoryID},
                new Product{ProductName = "Realme 11 Pro", UnitPrice = decimal.Parse("35000"), CategoryID = categories.Single(c => c.CategoryName == "Mobiles").CategoryID},
                new Product{ProductName = "Samsung Smart 52 Inch", UnitPrice = decimal.Parse("35000"), CategoryID = categories.Single(c => c.CategoryName == "TVs").CategoryID},

            };
        }

    }
}
