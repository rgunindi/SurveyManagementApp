using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project.BLL.Concrete;
using Project.BLL.ValidationRules;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;

namespace SurveyManagementApp.Areas.User.Controllers
{
    public class UserController : Controller
    {
        PersonelManager pm = new PersonelManager(new EfPersonelDal());
        SurveyManager sm = new SurveyManager(new EfSurveyDal(), new EfPersonelDal());
        SurveyQuestionManager sqm = new SurveyQuestionManager(new EfSurveyQuestionDal(), new EfSurveyDal());
        QuestionManager qm = new QuestionManager(new EfQuestionDal(), new EfSurveyQuestionDal());
        AnswerManager ansM = new AnswerManager(new EfAnswerDal(), new EfPersonelDal());
        SurveyQuestionAnswerManager sqam =
            new SurveyQuestionAnswerManager(new EfSurveyQuestionAnswerDal(), new EfQuestionDal());


        public ActionResult Index()
        {
            var user = (string) Session["UserName"];
            if (user == null)
            {
                return RedirectToAction("UserLogin", "Login", new { area = "Login" });
            }
            else
            {
                var p = pm.GetPersonelByUserName(user);
                ViewBag.personel = p;
                if (p.CompanyID == null) return View();
                var pList = pm.GetAllPersonelByCompanyID((int) p.CompanyID);
                ViewBag.perList = pList;
                return View(pList);
            }
        }

        [HttpGet]
        public ActionResult SolveSurvey()
        {
            var user = (string) Session["UserName"];
            if (user == null)
            {
                return RedirectToAction("UserLogin", "Login", new { area = "Login" });
            }
            else
            {
                var p = pm.GetPersonelByUserName(user);
                if (p.SurveyID == null) { ViewBag.NoData = true; return View();}
                var sId = (int) p.SurveyID;
                var s = sm.GetById((int) p.SurveyID);
                var surveyQuestions = sqm.GetBySurveyId(sId);
                var questions = surveyQuestions.Select(sQ => qm.GetBySurveyQId(sQ.SurveyQuestionID));
                var surveyQuestionAnswers = new List<SurveyQuestionAnswer>();

                foreach (var item in questions)
                {
                    var allAnswers = sqam.GetAll();
                    foreach (var answer in allAnswers)
                    {
                        var sqa = item.QuestionID == answer.QuestionID;
                        if (sqa)
                        {
                            surveyQuestionAnswers.Add(answer);
                        }
                    }
                }

                ViewBag.personel = p;
                ViewBag.survey = s;
                ViewBag.surveyQuestions = surveyQuestions;
                ViewBag.questions = questions;
                ViewBag.surveyQuestionAnswers = surveyQuestionAnswers;
                return View();
            }
        }

        [HttpPost]
        public ActionResult SolveSurvey(List<int> ids,List<string> values)
        {
            var u = (string) Session["UserName"];
            if (u == null)
            {return RedirectToAction("UserLogin", "Login",new {area="Login"});}
            var per=pm.GetPersonelByUserName(u);
            ansM.Add(ids,values,per); 
            pm.Update(per);
            return RedirectToAction("Index", "User", new { area = "User" });
        }

        [HttpGet]
        public ActionResult ChangeInfo()
        {
            var u = (string) Session["UserName"];
            if (u == null)
            {return RedirectToAction("UserLogin", "Login",new {area="Login"});}
            var per=pm.GetPersonelByUserName(u);
            return View(per);
        }

        [HttpPost]
        public ActionResult ChangeInfo(Personel p)
        {
            var result = new PersonelValidator().Validate(p);
            if (result.IsValid)
            {
                var per = pm.GetById(p.PersonelID);
                per.PersonelName = p.PersonelName;
                per.PersonelSurname = p.PersonelSurname; 
                per.PersonelPassword = p.PersonelPassword;
                pm.Update(per);
                return RedirectToAction("Index");
            }

            ViewBag.Error = result.Errors;
            return View(p);
        }
    }
}