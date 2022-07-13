using Project.DAL.Abstract;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.DAL.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _obj;

        public GenericRepository()
        {
            _obj = c.Set<T>();
        }

        public void Add(T entity)
        {
            _obj.Add(entity);
            c.SaveChanges();
        }

        public void Delete(int id)
        {
            c.Entry(_obj.Find(id)).State= EntityState.Deleted;
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            return _obj.Find(id);
        }

        public List<T> GetAll()
        {
            return _obj.ToList();
        }

        public void Update(T entity)
        {
            c.Entry(entity).State = EntityState.Modified;
            c.SaveChanges();
        }

        public List<T> GetAll(Func<T, bool> predicate)
        {
            return _obj.Where(predicate).ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return  _obj.Where(filter).SingleOrDefault();
        }
    }
}