using Project.BLL.Abstract;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public int GetPersonelWaitingSurvey()
        {
            return _personelDal.GetAll(x=>x.SurveyID!=null).Count;
        }
        public Personel GetPersonelInfo(Personel p)
        {
            return _personelDal
                .GetAll((x) =>
                    x.CompanyID == p.CompanyID && x.PersonelID != p.PersonelID && x.Role != p.Role)
                .FirstOrDefault();
        }

        public Personel GetPersonelByUserName(string userName)
        {
            return _personelDal.GetFirstOrDefault(x => x.UserName == userName);
        }

        public Personel GetPersonel(Personel p)
        {
            var uname = p.UserName;
            var pass = p.PersonelPassword;
            var personel = _personelDal.Get(x => x.UserName == uname&&x.PersonelPassword==pass);
            return personel;
        }

        public List<Personel> GetAllPersonelByCompanyID(int id, dynamic p)
        {
            var per = new List<Personel>();

            List<Personel> ReturnValue(dynamic param)
            {
                per = _personelDal.GetAll((x) => x.CompanyID == param).OrderByDescending(x => x.Role)
                    .ToList();
                return per;
            }

            return ReturnValue(id).Count > 0 ? per : ReturnValue(p);
        }

        public List<Personel> GetAllPersonelByCompanyID(int pCompanyId)
        {
            var per = _personelDal.GetAll((x) => x.CompanyID == pCompanyId).OrderByDescending(x => x.Role)
                .ToList();
            return per;
        }
    }
}