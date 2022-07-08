using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
    public interface IPersonelService
    {
        List<Personel> GetAll();
        Personel GetById(int id);
        void Add(Personel company);
        void Update(Personel company);
        void Delete(int id);
        List<Personel> GetAll(Func<Personel, bool> predicate);

    }
}
