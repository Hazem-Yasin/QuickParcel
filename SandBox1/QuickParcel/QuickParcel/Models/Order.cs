namespace QuickParcel.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }

        public Product Products { get; set; }
        public Customer Customers { get; set; }
    }
}
