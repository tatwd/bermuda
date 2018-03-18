using Bmd.App.Models;
using Bmd.Model;
using System.Linq;
using System.Web.Mvc;

namespace Bmd.App.Controllers
{
    public class AccountController : Controller
    {
        BmdEntities db = new BmdEntities();

        // GET: Account/SignIn
        public ActionResult SignIn()
        {
            return View();
        }

        // POST: Account/SignIn
        [HttpPost]
        public ActionResult SignIn(SignInViewModel vm)
        {
            BmdUser user = new BmdUser();

            if (ModelState.IsValid)
            {
                user = db.bmdUser
                    .Where(u => u.Name == vm.Name && u.Pwd == vm.Pwd)
                    .FirstOrDefault();

                return Json(user);
            }

            return View(); // test
        }

        // GET: Account/SignUp
        public ActionResult SignUp()
        {
            return View();
        }

        // POST: Account/SignUp
        [HttpPost]
        public ActionResult SignUp(SignUpViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return Json(vm); // test
            }

            return View();
        }
    }
}