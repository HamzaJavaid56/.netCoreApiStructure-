using DataEntities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CB_BusinessLogic.Services.CustomerService
{
  public  interface ICustomerService
    {
        public IEnumerable<Customers> GetAllCustomers();
        public List<Customers> PostCustomers(CustomersRequest obj);
     
    }
}
