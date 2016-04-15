using System.Web.Mvc;
using TrainChat.Service.Interfaces;
using TrainChat.Web.Api.Infrastructure;
using TrainChat.Web.Api.Models;

namespace TrainChat.Web.Api.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: User
        public ActionResult Index()
        {
            return View(userService.GetUsers().ToUserIndexViewModelList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                userService.Create(user.ToUserDto());
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(userService.GetById(id).ToUserViewModel());
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                userService.Update(user.ToUserDto());
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(userService.GetById(id).ToUserViewModel());
        }

        [HttpPost]
        public ActionResult Delete(UserViewModel user)
        {
            userService.Delete(user.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(userService.GetById(id).ToUserViewModel());
        }

        protected override void Dispose(bool disposing)
        {
            userService.Dispose();
            base.Dispose(disposing);
        }
    }
}