using System.Web.Mvc;

namespace SurveyManagementApp.Areas.Login
{
    public class LoginAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Login";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Login_default",
                "Login/{controller}/{action}/{id}",
                new {controller="Login",action = "UserLogin", id = UrlParameter.Optional }
            );
        }
    }
}