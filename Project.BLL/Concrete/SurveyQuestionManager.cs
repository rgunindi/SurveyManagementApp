using Project.DAL.Abstract;
using Project.ENTITIES.Concrete;
using System.Collections.Generic;
using System.Linq;
using Project.BLL.Abstract;

namespace Project.BLL.Concrete
{
    public class SurveyQuestionManager : ISurveyQuestionService
    {
        ISurveyQuestionDal _sQuestionDal;
        ISurveyDal _SurveyDal;

        public SurveyQuestionManager(ISurveyQuestionDal surveyQDal,ISurveyDal surveyDal)
        {
            _sQuestionDal=surveyQDal;
            _SurveyDal=surveyDal;
        }

        public List<SurveyQuestion> GetAll()
        {
            return _sQuestionDal.GetAll().ToList();
        }

        public SurveyQuestion GetById(int id)
        {
            return _sQuestionDal.GetById(id);
        }

        public void Add(SurveyQuestion survey)
        {
            _sQuestionDal.Add(survey);
        }
        public void Add(string surveyTitle,string qType)
        {
            
            var surveyId = _SurveyDal.GetAll().Last().SurveyID;

            _sQuestionDal.Add(new SurveyQuestion()
            {
                SurveyID =surveyId, 
                SurveyQuestionType = qType=="0"?SurveyQuestionType.SingleChoiceQuestion:qType=="1"?SurveyQuestionType.MultipleChoiceQuestions:SurveyQuestionType.OpenEndedQuestion,
            });
        }

        public  void Update(SurveyQuestion survey)
        {
           _sQuestionDal.Update(survey);
        }

        public void Delete(int id)
        {
            //degistirilecek
            _sQuestionDal.GetAll().Where(x => x.SurveyQuestionID == id).ToList();
        }
    }
}