using System.Web.Mvc;
using System.Web.Security;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;

namespace SurveyManagementApp.Areas.Login
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private AdminManager adM = new AdminManager(new EfAdminDal());
        private  PersonelManager pm = new PersonelManager(new EfPersonelDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Project.ENTITIES.Concrete.Admin admin)
        {
            if (!ModelState.IsValid) return View();
            var obj = adM.GetAdmin(admin);
            if (obj == null) return View();
            FormsAuthentication.SetAuthCookie(obj.AdminName, false);
            Session["AdminName"] = obj.AdminName;
            return RedirectToAction("index", "Admin");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public ActionResult LogoutPersonel()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("UserLogin", "Login");
        } 
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(Personel p)
        {
            // if (!ModelState.IsValid) return View();
            var obj = pm.GetPersonel(p);
            if (obj == null) return View();
            FormsAuthentication.SetAuthCookie(obj.UserName, true);
            Session["UserName"] = obj.UserName;
            Session["User"] = obj.FullName;
            return RedirectToAction("index", obj.Role==Role.Manager ? "Manager" : "User");
        }
    }
}