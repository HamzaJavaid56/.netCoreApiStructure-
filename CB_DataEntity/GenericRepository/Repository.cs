using AF.DataEntities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CB_DataEntity.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SpContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
      
        public Repository()
        {

        }
        public Repository(SpContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public List<T> GetAll()
        {
            return entities.ToList();
        }
        public T GetById(object id)
        {
            var res = entities.Find(id);
            return res;
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Can't insert NUll Values in Record");
            }
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Can't Update NUll Values in Record");
            }
            entities.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id can't be Null");
            }
            T existing = entities.Find(id);
            entities.Remove(existing);
            context.SaveChanges();
        }
    }
}
