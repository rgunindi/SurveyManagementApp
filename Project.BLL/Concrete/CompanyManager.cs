using Project.DAL.Abstract;
using Project.ENTITIES.Concrete;
using System.Collections.Generic;
using System.Linq;
using Project.BLL.Abstract;

namespace Project.BLL.Concrete
{
    public class CompanyManager : ICompanyService
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

        public  void Update(Company company)
        {
           _companyDal.Update(company);
        }

        public void Delete(int id)
        {
            _companyDal.GetAll().Where(x=>x.CompanyID==id).ToList()
                .ForEach(x=>x.CompanyPersonels.ToList().ForEach(y=>y.Company=null));
            _companyDal.Delete(id);
        }
    }
}