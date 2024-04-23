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
            };
        }

    }
}
