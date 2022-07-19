using System.Collections.Generic;
using System.Web.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;

namespace SurveyManagementApp.Areas.Survey.Controllers
{
    [Authorize(Roles = "Manager,Admin")]
    public class SurveyController : Controller
    {
        PersonelManager pm = new PersonelManager(new EfPersonelDal());
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        SurveyManager sm = new SurveyManager(new EfSurveyDal(), new EfPersonelDal());
        QuestionManager qm = new QuestionManager(new EfQuestionDal(), new EfSurveyQuestionDal());
        SurveyQuestionManager sqm = new SurveyQuestionManager(new EfSurveyQuestionDal(), new EfSurveyDal());
        SurveyQuestionAnswerManager sqam =
            new SurveyQuestionAnswerManager(new EfSurveyQuestionAnswerDal(), new EfQuestionDal());
        AnswerManager am = new AnswerManager(new EfAnswerDal(), new EfPersonelDal());

        [HttpGet]
        public ActionResult Index()
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Manager", "Survey", new {area = "Survey"});
            ViewBag.CompanyList = cm.GetAll();
            ViewBag.perList = pm.GetAll();
            ViewBag.SurveyList = sm.GetAll();
            return View();

        }

        [HttpPost]
        public ActionResult Index(string surveyTitle, List<string> values, string qType, string question,
            List<string> anonyms, List<string> ids, List<string> personels)
        {
            if (values == null || surveyTitle == null || qType == null || question == null)
            {
                return RedirectToAction("Index", "Survey", new {area = "Survey"});
            }
            
            sm.Add(anonyms, ids, personels, surveyTitle);
            sqm.Add(surveyTitle, qType);
            qm.Add(question);
            sqam.Add(values, qType);
            ViewBag.surveyTitle = surveyTitle;
            return RedirectToAction("Index", "Survey", new {area = "Survey"});
        }

        public PartialViewResult SurveyPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult SurveyAnswers()
        {
            var isAdmin = User.IsInRole("Admin");
            if (isAdmin)
            {
                ViewBag.isAdmin = true;
                var surveyInfo = am.GetAllInfo();
                ViewBag.surveyInfo = surveyInfo;
                return View();
            }

            var u = (string) Session["UserName"];
            if (u == null)
            {
                return RedirectToAction("UserLogin", "Login", new {area = "Login"});
            }

            var per = pm.GetPersonelByUserName(u);
            var surveyInfo2 = am.GetCompaniesByUserName(per);
            ViewBag.surveyInfo = surveyInfo2;

            return View(surveyInfo2);
        }

        [HttpGet]
        public ActionResult SurveyAnswerDetails(int id)
        {
            var detail = am.GetByPersonelIdList(id);
            var surveyQuestion = qm.GetAll(detail);
            ViewBag.surveyQuestion = surveyQuestion;
            ViewBag.detail = detail;

            return View();
        }

        [HttpGet]
        public ActionResult Manager()
        {
            var u = (string) Session["UserName"];
            if (u == null)
            {
                return RedirectToAction("UserLogin", "Login", new {area = "Login"});
            }
            var per = pm.GetPersonelByUserName(u);
            if (per.CompanyID == null)
            {
                return RedirectToAction("CreatePersonel", "Manager", new {area = "Manager"});
            }
            ViewBag.Company = cm.GetById((int)per.CompanyID);
            ViewBag.perList =  pm.GetAllPersonelByCompanyID((int) per.CompanyID);
            ViewBag.SurveyList = sm.GetAll();
            return View();
        }
    }
}