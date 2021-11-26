using DataEntities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CB_BusinessLogic.Services.GenericRepoEFCore
{
   public interface IGenericRepoEFCoreService
    {
        public List<Customers> GetAllByList();
        public Customers GetById(int id);
        public void AddNew(Customers obj);
        public void Update(Customers obj);
        public void Delete(int id);
    }
}
