using AF.DataEntities.Context;
using CB_WebAPI.Utilites;
using Dapper;
using DataEntities.Model;
using DataEntity1.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace CB_BusinessLogic.Services.CustomerService
{
    public class CustomerServices : ICustomerService
    {
        private readonly SpContext _context;
 
        public CustomerServices()
        { }

        public CustomerServices(SpContext context, IOptions<AppSettingsModel2> settings)
        {
            _context = context;
    
        }
        //   Using Sp with Dapper
        public IEnumerable<Customers> GetAllCustomers()
        {
            var proc = "";
            proc = "SP_GET_CUSTOMERS";
            var cus = SPRepoistory<Customers>.GetListWithSp(proc);
            return cus;
        }
        public List<Customers> PostCustomers(CustomersRequest obj)
        {
            string proc = "SP_GET_CUSTOMERS_By_ID";
            var parameters = new DynamicParameters();
            parameters.Add("@customer_id", obj.Customer_Id);
            var cus = SPRepoistory<Customers>.GetListWithStoreProcedure(proc, parameters);
            return cus;
        }

        // Get application.json section  in Class Library
        public string GetConnectionStringInClassLibray()
        {

            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            var sampleConnectionString = root.GetConnectionString("DefaultConnection");
            return sampleConnectionString;
        }
    }
}
