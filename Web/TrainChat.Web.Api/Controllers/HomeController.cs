using System.Globalization;
using System.Web.Mvc;
using TrainChat.Model;
using TrainChat.Repositories.UnitOfWork;

namespace TrainChat.Web.Api.Controllers
{
	public class HomeController : Controller
	{
	    private UnitOfWork unitOfWork;

	    public HomeController()
	    {
            unitOfWork = new UnitOfWork();            
        }

	    public ActionResult Index()
		{
		    ViewBag.Title = "Home Page";            
            var re = new RoleEntity { Name = "SuperUser2", Description = "SuperUserUser" };
	         unitOfWork.Role.Create(re);
             unitOfWork.Save();
	        re = unitOfWork.Role.Get(1);
	      //  ViewBag.test = test;
			return View();
		}

  /*      [HttpPost]
        public ActionResult Create(RoleEntity b)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Role.Create(b);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(b);
        }
   * */
        public ActionResult Index2()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
	}
}
