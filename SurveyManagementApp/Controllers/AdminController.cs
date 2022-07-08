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
            ViewBag.CompanyList = cm.GetAll();
            ViewBag.perList = pm.GetAll();
            return View();
        }
        [HttpGet]
        public ActionResult AddCompany()
        {
            var p = pm.GetAll();

            ViewBag.perList = p;
            return View();
        }
        [HttpPost]
        public ActionResult AddCompany(Company company, Personel p)
        {
            CompanyValidator companyValidator = new CompanyValidator();
            ValidationResult result = companyValidator.Validate(company);
            if (result.IsValid)
            {
                cm.Add(company);
                var pp = pm.GetById(p.PersonelID);
                pp.CompanyID = company.CompanyID;
                pp.Role = Role.Manager;
                pm.Update(pp);
                return RedirectToAction("Index");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            AddCompany();
            return View();

        }

        public ActionResult DeleteCompany(int id)
        {
            cm.Delete(id);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult UpdateCompany(int id)
        {
            var personels = pm.GetAll();
            //If Company doesnt have any person. Send unassigned persons.
            var p = personels.Where(x => x.CompanyID == id).OrderByDescending(x => x.Role).ToList();
            var pp = personels.Where(x => x.CompanyID == null).OrderByDescending(x => x.Role).ToList();
            ViewBag.perList = p.Count > 0 ? p : pp;
            var company = cm.GetById(id);
            ViewBag.company = company;
            return View();
        }
        [HttpPost]
        public ActionResult UpdateCompany(Company company, Personel p)
        {
            var c = company;

            cm.Update(c);
            //Every company must have a one manager
            if (p.Role != Role.Manager)
            {
                var pInfo = pm.GetAll().Where((x) => x.CompanyID == p.CompanyID && x.PersonelID != p.PersonelID && x.Role != p.Role).FirstOrDefault();
                if (pInfo != null)
                {
                    pInfo.Role = Role.Personel;
                    innerUp();
                }
                else
                {
                    innerUp();
                }
            }
            void innerUp()
            {
                var personelUp = pm.GetById(p.PersonelID);
                if (personelUp != null)
                {
                    personelUp.Role = Role.Manager;
                    personelUp.CompanyID = personelUp.CompanyID ?? c.CompanyID;
                    pm.Update(personelUp);
                }
            }
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult CreatePersonel()
        {
            ViewBag.perList = pm.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult CreatePersonel(Personel p,DateTime bornDate)
        {
            ValidationResult result = new PersonelValidator().Validate(p);
            if (result.IsValid)
            {
                pm.Add(p);
                return RedirectToAction("Index");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            CreatePersonel();
            return View();
        }
        
    }
}