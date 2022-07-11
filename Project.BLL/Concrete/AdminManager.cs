using System.Collections.Generic;
using Project.BLL.Abstract;
using Project.DAL.Abstract;
using Project.ENTITIES.Concrete;

namespace Project.BLL.Concrete
{
    public class AdminManager : IAdminService
    {
        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin GetAdmin(Admin admin)
        {
          return _adminDal.Get(x => x.AdminName == admin.AdminName && x.AdminPassword == admin.AdminPassword);
        }

        public Admin GetAdminByUserName(string userName)
        {
           return _adminDal.Get(x => x.AdminName == userName);
        }
    }
}