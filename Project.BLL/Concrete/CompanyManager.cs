using Project.BLL.Abstract;
using Project.DAL.Abstract;
using Project.DAL.Concrete.Repositories;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Concrete
{
    public class CompanyManager:ICompanyService
    {
        ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public List<Company> GetAll()
        {
            return _companyDal.GetAll().ToList();
        }
        public Company GetById(int id)
        {
            return _companyDal.GetById(id);
        }
        public void Add(Company company)
        {
            _companyDal.Add(company);
        }
        public void Update(Company company)
        {
            _companyDal.Update(company);
        }
        public void Delete(int id)
        {
            _companyDal.Delete(id);
        }
        
    }
}
