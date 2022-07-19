using System;
using Project.DAL.Abstract;
using Project.ENTITIES.Concrete;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Project.BLL.Abstract;

namespace Project.BLL.Concrete
{
    public class AnswerManager : IAnswerService
    {
        IAnswerDal _answerDal;
        IPersonelDal _personelDal; 
        public AnswerManager(IAnswerDal answerDal, IPersonelDal personelDal)
        {
            _answerDal = answerDal;
            _personelDal = personelDal;
        }
        public void Add(List<int> Ids, List<string> Values,Personel p)
        {
            var i = 0;
            foreach (var id in Ids)
            {
                _answerDal.Add(new Answer() { PersonelID = p.PersonelID, SurveyID = (int) p.SurveyID,IsAnonymous=p.IsAnonymous, SurveyQuestionID= id, PerAnswer = Values[i] });
                i++;
            }
            p.SurveyID = null;
            p.IsAnonymous = false;
        }

        public List<Answer> GetAll()
        {
           return _answerDal.GetAll();
        }
        public dynamic GetAllInfo()
        {
                  var answers = _answerDal.GetAll();
            var list=answers.Select(i=> _personelDal.GetById(i.PersonelID)).ToList().Distinct(); 
            object[] obj={list,answers};
            return obj;
        }
        public int GetAllPerCount()
        {
            var answers = _answerDal.GetAll();
            var list=answers.Select(i=> _personelDal.GetById(i.PersonelID)).ToList().Distinct(); 
            
            return list.Count();
        }
        public Answer GetByPersonelId(int id)
        {
            return _answerDal.GetById(id);
        }

        public List<Answer> GetByPersonelIdList(int id)
        {
            var aa = _answerDal.GetAll(x=>x.PersonelID==id).Select(x=>x.SurveyQuestionID).Distinct().ToList();
            var bb = new List<Answer>();
            foreach (var item in aa)
            {
                bb.Add(_answerDal.GetAll(x => x.PersonelID == id && x.SurveyQuestionID == item).FirstOrDefault());
            }
            _answerDal.GetAll().ForEach(i=>aa.Contains(i.SurveyQuestionID));
            return _answerDal.GetAll(x=>x.PersonelID==id).ToList();
        }

        public Answer GetBySurveyId(int id)
        {
            return _answerDal.Get(x => x.SurveyID == id);
        }

        public dynamic GetCompaniesByUserName(Personel per)
        {
            if (per.CompanyID==null)
            {
                return null;
            }

            var personels = _personelDal.GetAll(x => x.CompanyID == per.CompanyID);
                //.Where(x=>x.SurveyID==per.SurveyID);
            var answers = _answerDal.GetAll();
            // var result = from a in answers
            //              join p in personels
            //              on a.PersonelID equals p.PersonelID
            //              select new
            //              {
            //                  a.PerAnswer,
            //                  a.SurveyQuestionID,
            //                  p.CurrentComp,
            //                  p.IsAnonymous,
            //                  p.SurveyID,
            //              };
            // foreach (var VARIABLE in result)
            // {
            //     var c = VARIABLE;
            // }
            object[] obj={personels,answers}; 
            return obj;
        }
    }
}