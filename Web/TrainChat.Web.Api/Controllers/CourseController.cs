using System.Web.Mvc;
using TrainChat.Web.Api.Hubs;

namespace TrainChat.Web.Api.Controllers
{
    public class CourseController : Controller
    {
        private ChatHub _chHub;

        public CourseController()
        {
            _chHub = new ChatHub();
        }

        public ActionResult RoomInfo()
        {
            return View();
        }

        // GET: Course
        public ActionResult Index()
        {
            return View("Index", _chHub.GetAllChatRooms());
        }

        // GET: Course/Details/
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create()
        {
            return View();
        }

        // GET: Course/Create/5
        public ActionResult Create(string name, bool isPrivate)
        {
            if (ModelState.IsValid)
            {
                _chHub.AddNewRoom(name, isPrivate);
            }
            //return View("Index", _chHub.GetAllChatRooms());
            return RedirectToAction("Index","Course");
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            _chHub.DeleteRoomById(id);
            ViewBag.RoomName = _chHub.GetRoomNameById(id);
            return RedirectToAction("Index","Course");
        }
    }
}
