using System.Linq;
using System.Web.Mvc;
using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;

namespace AutomatedTellerMachine.Controllers
{
    [Authorize]
    public class CheckingAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CheckingAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: CheckingAccount/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}
        public ActionResult Details()
        {
            //var checkingAccount = new CheckingAccount
            //{
            //    AccountNumber = "0000123456",
            //    FirstName = "Satyadeep",
            //    LastName = "Behera",
            //    Balance = 500
            //};
            var userId = User.Identity.GetUserId();

            var checkingAccount = Enumerable.First(db.CheckingAccounts.Where(id => id.ApplicationUserId == userId));
            return View(checkingAccount);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DetailsForAdmin(int id)
        {

            var checkingAccount = db.CheckingAccounts.Find(id);
            return View("Details", checkingAccount);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult List()
        {
            return View(db.CheckingAccounts.ToList());
        }

        // GET: CheckingAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckingAccount/Create
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

        // GET: CheckingAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckingAccount/Edit/5
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

        // GET: CheckingAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckingAccount/Delete/5
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
        [Authorize]
        public ActionResult Statement(int id)
        {
            var checkingAccount = db.CheckingAccounts.Find(id);
            return View(checkingAccount.Transcations.ToList());
        }
    }
}
