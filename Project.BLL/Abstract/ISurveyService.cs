using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
    public interface ISurveyService
    {
        List<Survey> GetAll();
        Survey GetById(int id);
        void Add(Survey survey);
        void Add(List<string> anonyms,List<string> ids,List<string> personels,string surveyTitle);
        void Update(Survey survey);
        void Delete(int surveyId);
    }
}
