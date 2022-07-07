using Project.BLL.Concrete.Repositories;
using Project.DAL.Abstract;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Concrete
{
    public class PersonelManager : GenericRepository<Personel>
    {
        IPersonelDal _personelDal;

        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }
        public List<Personel> GetAll()
        {
            return _personelDal.GetAll().ToList();
        }
        public Personel GetById(int id)
        {
            return _personelDal.GetById(id);
        }
        public void Add(Personel p)
        {
            _personelDal.Add(p);
        }
        public void Update(Personel p)
        {
            _personelDal.Update(p);
        }
        public void Delete(int id)
        {
            _personelDal.Delete(id);
        }

    }
}
