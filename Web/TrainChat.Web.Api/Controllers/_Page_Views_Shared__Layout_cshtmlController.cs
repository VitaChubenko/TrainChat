using System.Globalization;
using System.Web.Mvc;

namespace TrainChat.Web.Api.Controllers
{
    public class _Page_Views_Shared__Layout_cshtmlController : Controller
    {
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }
    }
}