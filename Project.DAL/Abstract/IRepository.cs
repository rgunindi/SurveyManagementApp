using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Get(Expression<Func<T, bool>> filter);
        T GetFirstOrDefault(Expression<Func<T, bool>> firstEl);
        void Add(T company);
        void Update(T company);
        void Delete(int id);
        List<T> GetAll(Func<T, bool> predicate);
    }
}
