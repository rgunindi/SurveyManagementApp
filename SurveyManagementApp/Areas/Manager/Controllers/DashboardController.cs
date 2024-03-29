﻿using System.Web.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;

namespace SurveyManagementApp.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
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
            ViewBag.perSurveyList = pm.GetPersonelWaitingSurvey();
            ViewBag.SurveyRatio = am.GetAllPerCount();
            ViewBag.SolvedSurveyAnswerList = am.GetAll().Count;
            return View();
        }
    }
}