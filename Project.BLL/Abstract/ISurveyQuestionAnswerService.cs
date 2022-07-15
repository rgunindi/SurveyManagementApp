using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
    public interface ISurveyQuestionAnswerService
    {
        List<SurveyQuestionAnswer> GetAll();
        SurveyQuestionAnswer GetById(int id);
        SurveyQuestionAnswer GetByQuestionId(int id);
        void Add(SurveyQuestionAnswer sqa);
        void Add(List<string> answers,string qType);
        void Update(SurveyQuestionAnswer sqa);
     }
}
