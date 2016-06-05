using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace TrainChat.Web.Api.Controllers
{
    public class SettingsController : Controller
    {
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            return Redirect(returnUrl);
        }
    }
}