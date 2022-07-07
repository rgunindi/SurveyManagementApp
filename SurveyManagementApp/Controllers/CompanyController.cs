using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyManagementApp.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        public ActionResult Index()
        {
            return View();
        }
    }
}