using Project.BLL.Abstract;
using Project.DAL.Abstract;
using Project.ENTITIES.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Concrete
{
    public class SurveyQuestionAnswerManager : ISurveyQuestionAnswerService
    {
        ISurveyQuestionAnswerDal _sqaDal;
        IQuestionDal _QuestionDal;

        public SurveyQuestionAnswerManager(ISurveyQuestionAnswerDal sqaDal, IQuestionDal QuestionDal)
        {
            _sqaDal = sqaDal;
            _QuestionDal = QuestionDal;
        }

        public List<SurveyQuestionAnswer> GetAll()
        {
            return _sqaDal.GetAll();
        }

        public SurveyQuestionAnswer GetById(int id)
        {
            return _sqaDal.GetById(id);
        }
        public SurveyQuestionAnswer GetByQuestionId(int id)
        {
            return _sqaDal.GetFirstOrDefault(x=>x.QuestionID==id);
        }
        public void Add(SurveyQuestionAnswer sqa)
        {
            _sqaDal.Add(sqa);
        }

        public void Add(List<string> answers, string qType)
        {
            foreach (var answer in answers.Select(i => new SurveyQuestionAnswer()
                     {
                         Answer = qType!="2"?i:null,
                         SurveyQuestionType = qType == "0" ? SurveyQuestionType.SingleChoiceQuestion :
                             qType == "1" ? SurveyQuestionType.MultipleChoiceQuestions :
                             SurveyQuestionType.OpenEndedQuestion,

                         QuestionID = _QuestionDal.GetAll().Last().QuestionID
                     }))
            {
                _sqaDal.Add(answer);
            }
        }

        public void Update(SurveyQuestionAnswer sqa)
        {
            throw new System.NotImplementedException();
        }
    }
}