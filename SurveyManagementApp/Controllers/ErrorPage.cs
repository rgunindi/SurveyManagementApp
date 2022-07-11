using System.Web.Mvc;

namespace SurveyManagementApp.Controllers
{
    public class ErrorPage : Controller
    {
        // GET
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}