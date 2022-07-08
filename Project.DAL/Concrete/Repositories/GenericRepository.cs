using Project.DAL.Abstract;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

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
            var o = _obj.Find(id);
            var a = o.GetType();
            if (a.Name == "Company")
            {
                var el = this.c.Personels.Where(x => x.CompanyID == id);
                foreach (var item in el)
                {
                    item.CompanyID = null;
                    c.Entry(item).State = EntityState.Modified;
                }
                c.SaveChanges();
            }
            _obj.Remove(_obj.Find(id));
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
            c.SaveChangesAsync();
        }

        public List<T> GetAll(Func<T, bool> predicate)
        {
            return _obj.Where(predicate).ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _obj.SingleOrDefault();
        }

    }

}
