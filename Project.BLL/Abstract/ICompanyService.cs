using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
    public interface ICompanyService
    {
        List<Company> GetAll();
        Company GetById(int id);
        void Add(Company company);
        void Update(Company company);
        void Delete(int companyId);
    }
}
