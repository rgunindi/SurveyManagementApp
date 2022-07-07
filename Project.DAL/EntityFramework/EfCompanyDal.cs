using Project.DAL.Abstract;
using Project.DAL.Concrete.Repositories;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.EntityFramework
{
    public class EfCompanyDal: GenericRepository<Company> , ICompanyDal
    {
    }
}
