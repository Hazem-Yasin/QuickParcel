using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickParcel.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Product Name is Required")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        //FK
        public int? CategoryID { get; set; }
        //navigation properties -- relationship
        public Category Category { get; set; }

    }
}
