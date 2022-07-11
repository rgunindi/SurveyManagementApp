using FluentValidation.Results;
using Project.BLL.Concrete;
using Project.BLL.ValidationRules;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SurveyManagementApp.Controllers
{
    public class AdminController : Controller
    {

        PersonelManager pm = new PersonelManager(new EfPersonelDal());
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.CompanyList = cm.GetAll();
            ViewBag.perList = pm.GetAll();
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddCompany()
        {
            var p = pm.GetAll();

            ViewBag.perList = p;
            return View();
        }
        [Authorize]
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
        [Authorize]
        public ActionResult DeleteCompany(int id)
        {
            cm.Delete(id);
            return RedirectToAction("index");
        }
        [Authorize]
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
        [Authorize] 
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
                    InnerUp();
                }
                else
                {
                    InnerUp();
                }
            }
            void InnerUp()
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
        
        public ActionResult AutoCreate(int id)
        {   
            var p = new Personel();
            p.PersonelName=Faker.Name.First();
            p.PersonelSurname=Faker.Name.Last();
            p.BornDate = Faker.Identification.DateOfBirth();
            p.Role = Role.Personel;
            p.PersonelPassword = p.LoginCheck;
            p.CompanyID = id;
            pm.Add(p);
            return RedirectToAction("CreatePersonel");
        }
        [Authorize]
        [HttpGet]
        public ActionResult CreatePersonel()
        {
            ViewBag.perList = pm.GetAll();
            ViewBag.CompanyList = cm.GetAll();
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreatePersonel(Personel p)
        {
            var result = new PersonelValidator().Validate(p);
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