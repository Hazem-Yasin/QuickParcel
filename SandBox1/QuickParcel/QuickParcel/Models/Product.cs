using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickParcel.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
