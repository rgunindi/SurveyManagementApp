using System.Web.Mvc;
using System.Web.Security;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;

namespace SurveyManagementApp.Controllers
{
    public class LoginController : Controller
    {
        private AdminManager adM = new AdminManager(new EfAdminDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            if (!ModelState.IsValid) return View();
            var obj = adM.GetAdmin(admin);
            if (obj == null) return View();
            FormsAuthentication.SetAuthCookie(obj.AdminName, false);
            Session["AdminName"] = obj.AdminName;
            return RedirectToAction("index", "Admin");
        }
    }
}