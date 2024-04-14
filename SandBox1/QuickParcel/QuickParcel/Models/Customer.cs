using System;
using System.Collections.Generic;


namespace QuickParcel.Models
{
    public class Customer
    {
        //The StudentID Propertry is the primary key
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //this is the one to many relationship, as one customer can have multiple Orders
        //but every order must have only one customer

        //this is also called the navigation property
        public ICollection<Order> Orders { get; set; }

    }
}
