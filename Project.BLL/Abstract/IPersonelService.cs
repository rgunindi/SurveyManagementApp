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
        void Add(Personel p);
        void Update(Personel p);
        void Delete(int id);
        List<Personel> GetAll(Func<Personel, bool> predicate);
        Personel GetPersonelInfo(Personel p);
        Personel GetPersonelByUserName(string userName);
        List<Personel> GetAllPersonelByCompanyID(int id,dynamic p);
        
    }
}
