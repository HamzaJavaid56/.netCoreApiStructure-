using AF.DataEntities.Context;
using CB_DataEntity.Context;
using DataEntities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CB_BusinessLogic.Services.EfCoreCrud
{
    public class EfCoreCrudService : IEfCoreCrudService
    {
        private readonly SpContext db;
        public EfCoreCrudService()
        {
            db = new SpContext();
        }
        //   Directly By Database
        public List<Customers> GetCustomersList()
        {
            return db.Customers.ToList();
        }
        public Customers GetCustomersById(int id)
        {     
           //var res= db.Customers.FromSqlRaw("select  * from Customers where id="+id).FirstOrDefault();
            return db.Customers.FirstOrDefault(res => res.id == id);         
        }
        public void InsertCustomer(Customers obj)
        {
            db.Customers.Add(obj);
            db.SaveChanges();
        }
        public void UpdateCustomer(Customers obj)
        {
            db.Customers.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteCustomer(int id)
        {
            db.Remove(db.Customers.Find(id));
            db.SaveChanges();
            
        }
    }
}
