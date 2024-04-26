using System.ComponentModel.DataAnnotations;

namespace QuickParcelApi.Models
{
    public class Category
    {

        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(100)]
        public string CategoryName { get; set; }
        public ICollection<Product>? Products { get; set; }

    }
}
