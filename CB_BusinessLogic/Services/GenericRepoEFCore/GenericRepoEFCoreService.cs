using CB_DataEntity.GenericRepository;
using DataEntities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CB_BusinessLogic.Services.GenericRepoEFCore
{
  public  class GenericRepoEFCoreService : IGenericRepoEFCoreService
    {
        IRepository<Customers> repo;
        //IRepository<CustomersRequest> repo2;
        public GenericRepoEFCoreService()
        {
            
        }
        public GenericRepoEFCoreService(
                    IRepository<Customers> repo
                   //IRepository<Modal-here> repo2
            )
        {
            this.repo = repo;
            //this.repo2 = repo2;   
        }
        public   List<Customers> GetAllByList()
        {
            var result = this.repo.GetAll();
            return result;
        }
        public Customers GetById(int id)
        {
            var result = this.repo.GetById(id);
            return result;     
        }
        public void AddNew(Customers obj)
        {            
            this.repo.Insert(obj);
        }
        public void Update(Customers obj)
        {
            this.repo.Update(obj);
        }
        public void Delete(int id)
        {
            this.repo.Delete(id);
        }
    }
}
