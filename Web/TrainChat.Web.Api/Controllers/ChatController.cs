using System.Web.Mvc;
using TrainChat.Web.Api.Hubs;

namespace TrainChat.Web.Api.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chat(string login, string password)
        {
            ViewBag.userName = login;           
            return View("Chat");
        }
    }
}