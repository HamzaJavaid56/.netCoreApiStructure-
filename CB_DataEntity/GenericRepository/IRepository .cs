using System;
using System.Collections.Generic;
using System.Text;

namespace CB_DataEntity.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object entity);
    }
}
