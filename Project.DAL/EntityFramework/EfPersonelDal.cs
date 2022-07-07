using Project.DAL.Abstract;
using Project.DAL.Concrete.Repositories;
using Project.ENTITIES.Concrete;
namespace Project.DAL.EntityFramework
{
    public class EfPersonelDal : GenericRepository<Personel> , IPersonelDal
    {
    }
}
