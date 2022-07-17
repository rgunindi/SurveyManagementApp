using System.Web.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;

namespace SurveyManagementApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        PersonelManager pm = new PersonelManager(new EfPersonelDal());
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        SurveyManager sm = new SurveyManager(new EfSurveyDal(),new EfPersonelDal());
        AnswerManager am = new AnswerManager(new EfAnswerDal(),new EfPersonelDal());
        public ActionResult Index()
        {
            ViewBag.CompanyList = cm.GetAll().Count;
            ViewBag.perList = pm.GetAll().Count; 
            ViewBag.SurveyList = sm.GetAll().Count;
            ViewBag.SolvedSurveyAnswerList = am.GetAll().Count;
            return View();
        }
    }
}