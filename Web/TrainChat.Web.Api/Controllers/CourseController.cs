using System.Linq;
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

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
