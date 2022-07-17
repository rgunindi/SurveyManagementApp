using System.Web.Mvc;
using System.Web.Security;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;

namespace SurveyManagementApp.Areas.Login.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private AdminManager adM = new AdminManager(new EfAdminDal());
        private  PersonelManager pm = new PersonelManager(new EfPersonelDal());
        [HttpGet]
        public ActionResult Index()
        {
            var admin = Session["AdminName"];
            if (admin != null)
            {
                return RedirectToAction("index", "Admin", new { area = "Admin" }); 
            }

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
            return RedirectToAction("index", "Admin", new { area = "Admin" });
        }
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login", new { area = "Login" });
        }
        [HttpGet]
        public ActionResult LogoutPersonel()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("UserLogin", "Login", new { area = "Login" });
        } 
        [HttpGet]
        public ActionResult UserLogin()
        {
            var uname = Session["UserName"];
            if (uname!=null)
            {
                var user = pm.GetPersonelByUserName(uname.ToString()); 
                return RedirectToAction("index", user.Role==Role.Manager ? "Manager" : "User",
                    user.Role==Role.Manager ? new { area = "Manager" } : new { area = "User" }); 
            } 
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(Personel p)
        {
            // if (!ModelState.IsValid) return View();
            var user = pm.GetPersonel(p);
            if (user == null) return View();
            FormsAuthentication.SetAuthCookie(user.UserName, true);
            Session["UserName"] = user.UserName;
            Session["User"] = user.FullName;
            return RedirectToAction("index", user.Role==Role.Manager ? "Manager" : "User",
                user.Role==Role.Manager ? new { area = "Manager" } : new { area = "User" });
        }
    }
}