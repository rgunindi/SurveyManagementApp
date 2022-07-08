using Project.DAL.Abstract;
using Project.BLL.Concrete.Repositories;
using Project.ENTITIES.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Concrete
{
    public class CompanyManager: GenericRepository<Company>
    {
        ICompanyDal _companyDal;
        IRepository<Company> _companyRepository;
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
