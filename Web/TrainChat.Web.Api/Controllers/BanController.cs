using System.Web.Mvc;
using TrainChat.Web.Api.Hubs;

namespace TrainChat.Web.Api.Controllers
{
    public class BanController : Controller
    {
        private ChatHub _chHub;

        public BanController()
        {
            _chHub = new ChatHub();
        }

        // GET: Ban
        public ActionResult Index()
        {
            return View("Index", _chHub.GetUsers());
        }
    }
}