using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataEntities.Model
{
    public class Customers
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public string address { get; set; }

        //[Column(TypeName = "varchar(50)")]
        //public string Customer_lname { get; set; }

        //[Column(TypeName = "varchar(50)")]
        //public string Address { get; set; }

        //[Column(TypeName = "varchar(50)")]
        //public string City { get; set; }

       
    }

    public class CustomersRequest
    {
        [Key]
        public int Customer_Id { get; set; }
        public string Customer_Fname { get; set; }
        public string Customer_lname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }


}
