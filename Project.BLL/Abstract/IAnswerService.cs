using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
    public interface IAnswerService
    {
        List<Answer> GetAll();
        dynamic GetAllInfo();
        Answer GetByPersonelId(int id);
        List<Answer> GetByPersonelIdList(int id);
        Answer GetBySurveyId(int id);
        void Add(List<int> Ids,List<string> Values,Personel p);
    }
}
