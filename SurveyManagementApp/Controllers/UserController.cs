using System.Web.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;

namespace SurveyManagementApp.Controllers
{
    public class UserController : Controller
    {
        CompanyManager cm = new CompanyManager(new EfCompanyDal());

        PersonelManager pm = new PersonelManager(new EfPersonelDal());

        // GET
        
        public ActionResult Index()
        {
            var user = (string) Session["UserName"];
            if (user == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }
            else
            {
                var p = pm.GetPersonelByUserName(user);
                ViewBag.personnel = p;
                if (p.CompanyID == null) return View();
                var pList = pm.GetAllPersonelByCompanyID((int) p.CompanyID);
                ViewBag.perList = pList;
                return View(pList);
            }
        }
    }
}