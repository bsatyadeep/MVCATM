using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccountId = Enumerable.First(db.CheckingAccounts.Where(id => id.ApplicationUserId == userId)).Id;
            ViewBag.CheckingAccountId = checkingAccountId;
            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            ViewBag.Pin = user.Pin;
            return View();
            //return PartialView();
        }
        //[ActionName("about-this-atm")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.TheMessage = "You have trouble? please contact us.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.TheMessage = "We got your message!";
            return View();
            //return PartialView("_ContactThanks");
        }
        public ActionResult Serial(string letterCase)
        {
            var serialNumber = "ASPNETMVC5ATM1";
            if (letterCase == "lower")
            {
                return Content(serialNumber.ToLower());
            }

            return Content(serialNumber.ToUpper());
            //return new HttpStatusCodeResult(403);
            //return Json(new { name = "Serial", value = serialNumber }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Foo()
        {
            return View("About");
        }
    }
}