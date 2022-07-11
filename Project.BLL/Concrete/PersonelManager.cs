using Project.BLL.Concrete.Repositories;
using Project.BLL.Abstract;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Abstract;

namespace Project.BLL.Concrete
{
    public class PersonelManager : IPersonelService
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

        public List<Personel> GetAll(Func<Personel, bool> predicate)
        {
            return _personelDal.GetAll(predicate);
        }

        public Personel GetPersonelInfo(Personel p)
        {
            return _personelDal
                .GetAll((x) => x.CompanyID == p.CompanyID && x.PersonelID != p.PersonelID && x.Role != p.Role)
                .FirstOrDefault();
        }

        public List<Personel> GetAllPersonelByCompanyID(int id, dynamic p)
        {
            List<Personel> per = null;
            List<Personel> ReturnValue(dynamic param)
            {
                    per=_personelDal.GetAll((x) => x.CompanyID == param).OrderByDescending(x => x.Role).ToList();
                    return per;
            }

            return ReturnValue(id).Count > 0 ? per :ReturnValue(p);
        }
    }
}