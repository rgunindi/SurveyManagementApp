using Project.DAL.Abstract;
using Project.ENTITIES.Concrete;
using System.Collections.Generic;
using System.Linq;
using Project.BLL.Abstract;

namespace Project.BLL.Concrete
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _sQuestionDal;
        ISurveyQuestionDal _surveyqDal;
        public QuestionManager(IQuestionDal surveyQDal, ISurveyQuestionDal surveyqDal)
        {
            _sQuestionDal = surveyQDal;
            _surveyqDal = surveyqDal;
        }

        public List<Question> GetAll()
        {
            return _sQuestionDal.GetAll().ToList();
        }

        public Question GetById(int id)
        {
            return _sQuestionDal.GetById(id);
        }

        public void Add(Question survey)
        {
            _sQuestionDal.Add(survey);
        }

        public void Add(string question)
        {
            var qId = _surveyqDal.GetAll().Last().SurveyQuestionID;

            _sQuestionDal.Add(new Question()
            {
                SurveyQuestionID = qId,
                Q = question
            });
       }

        public void Update(Question survey)
        {
            _sQuestionDal.Update(survey);
        }
    }
}