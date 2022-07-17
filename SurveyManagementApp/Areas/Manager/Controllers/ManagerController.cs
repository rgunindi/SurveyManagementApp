﻿using System.Collections.Generic;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using System.Web.Mvc;
using Project.BLL.ValidationRules;
using Project.ENTITIES.Concrete;

namespace SurveyManagementApp.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        PersonelManager pm = new PersonelManager(new EfPersonelDal());
       
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CompanyList = cm.GetAll();
            ViewBag.perList = pm.GetAll();
            return View();
        }

        public ActionResult AutoCreate(int id)
        {
            var p = new Personel();
            p.PersonelName = Faker.Name.First();
            p.PersonelSurname = Faker.Name.Last();
            p.BornDate = Faker.Identification.DateOfBirth();
            p.Role = Role.Personel;
            p.PersonelPassword = p.LoginCheck;
            p.CompanyID = id;
            pm.Add(p);
            return RedirectToAction("CreatePersonel");
        }


        [HttpGet]
        public ActionResult CreatePersonel()
        {
            ViewBag.perList = pm.GetAll();
            ViewBag.CompanyList = cm.GetAll();
            return View();
        }


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

        [HttpGet]
        public ActionResult UpdateCompany(int id)
        {
            //If Company doesnt have any person. Send unassigned persons.
            var p = pm.GetAllPersonelByCompanyID(id, null);
            ViewBag.perList = p;
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
                var pInfo = pm.GetPersonelInfo(p);
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
                if (personelUp == null) return;
                personelUp.Role = Role.Manager;
                personelUp.CompanyID = personelUp.CompanyID ?? c.CompanyID;
                pm.Update(personelUp);
            }

            return RedirectToAction("index");
        }
        
        [HttpGet]
        public ActionResult ChangeInfo()
        {
            var u = (string) Session["UserName"];
            if (u == null)
            {return RedirectToAction("UserLogin", "Login",new {area="Login"});}
            var per=pm.GetPersonelByUserName(u);
            return View(per);
        }

        [HttpPost]
        public ActionResult ChangeInfo(Personel p)
        {
            var result = new PersonelValidator().Validate(p);
            if (result.IsValid)
            {
                var per = pm.GetById(p.PersonelID);
                per.PersonelName = p.PersonelName;
                per.PersonelSurname = p.PersonelSurname; 
                per.PersonelPassword = p.PersonelPassword;
                pm.Update(per);
                return RedirectToAction("Index");
            }
                ViewBag.Error = result.Errors;
                return View(p);
        }
    }
}