using System.Linq;
using FluentValidation.Results;
using Project.BLL.Concrete;
using Project.BLL.ValidationRules;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;
using System.Web.Mvc;
using PagedList;

namespace SurveyManagementApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        PersonelManager pm = new PersonelManager(new EfPersonelDal());
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
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
        
        public ActionResult AutoCreate(int id)
        {
            var p = new Personel();
            p.PersonelName = Faker.Name.First();
            p.PersonelSurname = Faker.Name.Last();
            p.BornDate = Faker.Identification.DateOfBirth();
            p.Role = Role.Personel;
            p.PersonelPassword = p.LoginCheck;
            p.UserName = p.PersonelName + p.PersonelID;
            if(id!=0)
                p.CompanyID = id;
            pm.Add(p);
            return RedirectToAction("CreatePersonel");
        }

        
        [HttpGet]
        public ActionResult CreatePersonel()
        {
            var c= cm.GetAll();
            c.Insert(0, new Company() { CompanyID =  0, CompanyName = "No assignment" });
            ViewBag.perList = pm.GetAll();
            ViewBag.CompanyList = c;
            return View();
        }

        
        [HttpPost]
        public ActionResult CreatePersonel(Personel p)
        {
            var result = new PersonelValidator().Validate(p);
            if (result.IsValid)
            {
                p.UserName = p.CheckUserName;
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

        
        public ActionResult PersonelList(int page = 1)
        {
            var p = pm.GetAll().ToPagedList(page, 10);
            return View(p);
        }
        
        public ActionResult DeletePersonel(int id)
        {
            pm.Delete(id);
            return RedirectToAction("PersonelList");
        }
    }
}