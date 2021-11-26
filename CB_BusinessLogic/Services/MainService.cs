using CB_BusinessLogic.Services.CustomerService;
using CB_BusinessLogic.Services.EfCoreCrud;
using CB_BusinessLogic.Services.GenericRepoEFCore;
using CB_DataEntity.GenericRepository;
using DataEntities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CB_BusinessLogic.Services
{
    public class MainService : IMainService
    {
        ICustomerService _ICustomerService;
        IEfCoreCrudService _IEfCoreCrudService;
        public MainService()
        {
            _ICustomerService = new CustomerServices();
            _IEfCoreCrudService = new EfCoreCrudService();
        }
        #region Customers
        public IEnumerable<Customers> GetAllCustomers()
        {
            return _ICustomerService.GetAllCustomers();
        }
        public List<Customers> PostCustomers(CustomersRequest obj)
        {
            return _ICustomerService.PostCustomers(obj);
        }
        #endregion

        #region EfCrud
        public List<Customers> GetCustomersList()
        {
            return _IEfCoreCrudService.GetCustomersList();
        }
        public Customers GetCustomersById(int id)
        {
            return _IEfCoreCrudService.GetCustomersById(id);
        }
        public void InsertCustomer(Customers obj)
        {
            _IEfCoreCrudService.InsertCustomer(obj);
        }
        public void UpdateCustomer(Customers obj)
        {
            _IEfCoreCrudService.UpdateCustomer(obj);
        }
        public void DeleteCustomer(int id)
        {
            _IEfCoreCrudService.DeleteCustomer(id); ;
        }
        #endregion
    }
}


//Scaffold - DbContext {-Connection-string-in-quotations-}
//Microsoft.EntityFrameWorkCore.SqlServer-outputdir Repository / Models - context {= databasename -}
//DbContext - contextdir Repository - DataAnnotations - Force