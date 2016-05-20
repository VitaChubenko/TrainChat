using System.Web.Mvc;

namespace TrainChat.Web.Api.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}
