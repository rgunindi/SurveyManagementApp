using System;
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
        private IPersonelDal _personelDal;

        public SurveyManager(ISurveyDal surveyDal, IPersonelDal personelDal)
        {
            _personelDal = personelDal;
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

        public void Add(List<string> anonyms, List<string> ids, List<string> personels, string surveyTitle)
        {
            int count = 0;
            if (personels==null)
            {
                var sId = _surveyDal.GetFirstOrDefault(x => x.SurveyTitle == surveyTitle).SurveyID;
                if (sId == null || sId == 0)
                {
                    var survey = new Survey()
                    {
                        SurveyTitle = surveyTitle, SurveyStatus = true
                    };
                    _surveyDal.Add(survey);
                }
                return;
            }
            foreach (var p in personels)
            {
                count++;
                var pId = Convert.ToInt32(p);
                @return:
                var s = _surveyDal.GetFirstOrDefault(x => x.SurveyTitle == surveyTitle);
                if (s==null)
                {
                    var survey = new Survey()
                    {
                        SurveyTitle = surveyTitle, SurveyStatus = true
                    };
                    _surveyDal.Add(survey);
                    goto @return;
                }
                var sId = s.SurveyID;
                var personel = _personelDal.GetById(pId);
                personel.SurveyID = Convert.ToInt32(sId);
                int idCount = 0;
                bool isAnonym = false;
                if (anonyms != null)
                {
                    foreach (var i in ids)
                    {
                        idCount++;
                        isAnonym = anonyms.Contains(i);
                        if (isAnonym)
                        {
                            if (count == idCount)
                            {
                                break;
                            }

                            isAnonym = false;
                        }
                    }
                }

                personel.IsAnonymous = isAnonym;
                _personelDal.Update(personel);
            }
            // _surveyDal.Add(new Survey(){SurveyTitle = survey[0],SurveyStatus = true});
        }

        public void Update(Survey survey)
        {
            _surveyDal.Update(survey);
        }

        public void Delete(int id)
        {
            _surveyDal.GetAll().Where(x => x.SurveyID == id).ToList()
                .ForEach(x => x.SurveyStatus = false);
        }
    }
}