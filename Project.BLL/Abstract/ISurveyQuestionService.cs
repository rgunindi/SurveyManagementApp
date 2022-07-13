using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
    public interface ISurveyQuestionService
    {
        List<SurveyQuestion> GetAll();
        SurveyQuestion GetById(int id);
        void Add(SurveyQuestion surveyQuestion);
        void Add( string surveyTitle,string qType);
        void Update(SurveyQuestion surveyQuestion);
        void Delete(int surveyQuestionId);
    }
}
