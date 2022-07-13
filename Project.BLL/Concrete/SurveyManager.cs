using Project.DAL.Abstract;
using Project.ENTITIES.Concrete;
using System.Collections.Generic;
using System.Linq;
using Project.BLL.Abstract;

namespace Project.BLL.Concrete
{
    public class SurveyManager : ISurveyService
    {
        ISurveyDal _surveyDal;

        public SurveyManager(ISurveyDal surveyDal)
        {
            _surveyDal = surveyDal;
        }

        public List<Survey> GetAll()
        {
            return _surveyDal.GetAll().ToList();
        }

        public Survey GetById(int id)
        {
            return _surveyDal.GetById(id);
        }

        public void Add(Survey survey)
        {
            _surveyDal.Add(survey);
        }

        public void Add(params string[] survey)
        {
            _surveyDal.Add(new Survey(){SurveyTitle = survey[0],SurveyStatus = true});
            
        }

        public  void Update(Survey survey)
        {
           _surveyDal.Update(survey);
        }

        public void Delete(int id)
        {
            _surveyDal.GetAll().Where(x => x.SurveyID == id).ToList()
                .ForEach(x=>x.SurveyStatus=false);
        }
    }
}