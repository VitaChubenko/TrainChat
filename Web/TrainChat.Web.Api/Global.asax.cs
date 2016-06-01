using System;
using System.Globalization;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using TrainChat.Web.Api.Models;

namespace TrainChat.Web.Api
{
    public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session != null)
            {
                CultureInfo ci = (CultureInfo)this.Session["Culture"];

                if (ci == null)
                {
                    string langName = "en";

                    if (HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length != 0)
                    {
                        langName = HttpContext.Current.Request.UserLanguages[0].Substring(0, 2);
                    }
                    ci = new CultureInfo(langName);
                    this.Session["Culture"] = ci;
                }

                Thread.CurrentThread.CurrentUICulture = ci;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (Request.IsAuthenticated == true)
                {
                    var ticket = FormsAuthentication.Decrypt(Context.Request.Cookies[FormsAuthentication.FormsCookieName].Value);
                    var roles = ticket.UserData.Split(';');
                    var id = new FormsIdentity(ticket);
                    Context.User = new GenericPrincipal(id, roles);
                }
            }
        }

        //protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        //{
        //    HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

        //    if (authCookie != null)
        //    {
        //        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

        //        JavaScriptSerializer serializer = new JavaScriptSerializer();

        //        CustomPrincipalSerializeModel serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);

        //        CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
        //        newUser.Login = serializeModel.Login;
        //        newUser.Password = serializeModel.Password;

        //        HttpContext.Current.User = newUser;
        //    }
        //}
    }
}
