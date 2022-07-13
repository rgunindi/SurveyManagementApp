using System.Collections.Generic;
using System.Web.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;

namespace SurveyManagementApp.Controllers
{   
    [Authorize(Roles = "Manager,Admin")]
    public class SurveyController : Controller
    {
        PersonelManager pm = new PersonelManager(new EfPersonelDal());
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        SurveyManager sm = new SurveyManager(new EfSurveyDal());
        QuestionManager qm = new QuestionManager(new EfQuestionDal(), new EfSurveyQuestionDal());
        SurveyQuestionManager sqm = new SurveyQuestionManager(new EfSurveyQuestionDal(), new EfSurveyDal());
        SurveyQuestionAnswerManager sqam = new SurveyQuestionAnswerManager(new EfSurveyQuestionAnswerDal(), new EfQuestionDal());
        
        [HttpGet]
        public ActionResult Index(List<Personel> p=null)
        {
            ViewBag.CompanyList = cm.GetAll();
            ViewBag.perList = pm.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Index(List<string> values,string surveyTitle, string qType,string question,List<string> anonyms,List<string> ids,List<string> personels) 
        {
            if (values==null||surveyTitle==null||qType==null||question==null)
            {
                return View();
            }
            sm.Add(surveyTitle);
            sqm.Add(surveyTitle,qType); 
            qm.Add(question);
            sqam.Add(values,qType);
            ViewBag.surveyTitle = surveyTitle;
            return View();
        }
        public PartialViewResult SurveyPartial()
        {
            return PartialView();
        }
        public ActionResult ListPersonel(int CompanyID)
        {
            var p= (List<Personel>) pm.GetAllPersonelByCompanyID(CompanyID);
            Index(p);
            return View("Index",p);
        }
    }
}