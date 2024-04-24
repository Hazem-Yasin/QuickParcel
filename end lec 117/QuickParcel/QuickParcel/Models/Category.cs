using System.ComponentModel.DataAnnotations;

namespace QuickParcel.Models
{
    public class Category
    {

        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Category Name Is Required")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }


        public ICollection<Product> Products{ get; set;}
    }
}
