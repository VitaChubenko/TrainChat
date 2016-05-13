using System.Web.Mvc;

namespace TrainChat.Web.Api.Controllers
{
    public class _Page_Views_Course_Index_cshtmlController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index","Course");
        }
    }
}