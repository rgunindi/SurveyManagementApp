using Project.DAL.Abstract;
using Project.DAL.Concrete.Repositories;
using Project.ENTITIES.Concrete;

namespace Project.DAL.EntityFramework
{
    public class EfAnswerDal: GenericRepository<Answer>, IAnswerDal
    {
    }
}
