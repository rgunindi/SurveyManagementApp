using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyManagementApp.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        PersonelManager pm = new PersonelManager(new EfPersonelDal());
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Role = nameof(ManagerController);
            ViewBag.Manager=cm;//Giris yapan manager id si gidecek
            return RedirectToAction("index","Admin");
        }
    }
}