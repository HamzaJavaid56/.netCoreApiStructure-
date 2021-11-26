using DataEntities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CB_BusinessLogic.Services.EfCoreCrud
{
  public  interface IEfCoreCrudService
    {
        public List<Customers> GetCustomersList();
        public Customers GetCustomersById(int id);
        public void InsertCustomer(Customers obj);
        public void UpdateCustomer(Customers obj);
        public void DeleteCustomer(int id);

    }
}
