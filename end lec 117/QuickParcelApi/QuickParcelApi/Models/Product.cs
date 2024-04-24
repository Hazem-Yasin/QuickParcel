using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickParcelApi.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage ="Product Name is Required")]
        [StringLength(50, MinimumLength = 2)]
        public string ProductName { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "smallmoney")]
        public decimal UnitPrice { get; set; }

        public int CategoryID { get; set; }

        public Category? Category { get; set; }


    }
}
