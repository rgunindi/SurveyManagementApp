using Project.DAL.Abstract;
using Project.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Concrete.Repositories
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
            c.SaveChanges();
        }

        public List<T> GetAll(Func<T, bool> predicate)
        {
            return _obj.Where(predicate).ToList();
        }
    }

}
