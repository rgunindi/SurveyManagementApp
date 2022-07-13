using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
    public interface IQuestionService
    {
        List<Question> GetAll();
        Question GetById(int id);
        void Add(Question Question);
        void Add( string Question);
        void Update(Question Question);
    }
}
