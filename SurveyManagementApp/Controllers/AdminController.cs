using FluentValidation.Results;
using Project.BLL.Concrete;
using Project.BLL.ValidationRules;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyManagementApp.Controllers
{
    public class AdminController : Controller
    {
       
        PersonelManager pm = new PersonelManager(new EfPersonelDal());
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        public IEnumerable<EfCompanyDal> Companies { get; set; }
        public IEnumerable<EfPersonelDal> Personels { get; set; }
        public ActionResult Index()
        {
            var companyvalues = cm.GetAll();
            return View(companyvalues);
        }
        [HttpGet]
        public ActionResult AddCompany()
        {
            var p= pm.GetAll();
          
            ViewBag.perList = p;
            return View();
        }
        [HttpPost]
        public ActionResult AddCompany(Company company,Personel p)
        {
            CompanyValidator companyValidator = new CompanyValidator();
            ValidationResult result = companyValidator.Validate(company);
            if (result.IsValid)
            {
                cm.Add(company);
                var pp = pm.GetById(p.PersonelID);
                pp.CompanyID=company.CompanyID;
                pp.Role = Role.Manager;
                pm.Update(pp);
                return RedirectToAction("Index");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            AddCompany();
            return  View();

        }
    }
}