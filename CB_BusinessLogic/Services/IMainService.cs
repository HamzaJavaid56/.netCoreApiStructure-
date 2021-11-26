using DataEntities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CB_BusinessLogic.Services
{
 //   For Registring All the Services in one Place.
    public  interface IMainService
    {
        #region CustomerServices
        public IEnumerable<Customers> GetAllCustomers();
        public List<Customers> PostCustomers(CustomersRequest obj);
        #endregion

        #region EfCrudServices
        public List<Customers> GetCustomersList();
        public Customers GetCustomersById(int id);
        public void InsertCustomer(Customers obj);
        public void UpdateCustomer(Customers obj);
        public void DeleteCustomer(int id);
        #endregion
    }
}
