using Solo.Domain;
using Solo.Domain.Repository;
using Solo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Solo.Controllers
{
    public class LogRegController : Controller
    {
        private readonly ILogRegRepository logregRepo = new LogRegRepository();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserBo user)
        {
            if(logregRepo.isValid(user))
            {
                UserBo userBo = logregRepo.GetUserByName(user.Username);
                HttpCookie httpCookie = new HttpCookie("additionalCookie");
                httpCookie.Values.Add("username", userBo.Username);
                httpCookie.Values.Add("password", userBo.Password);
                httpCookie.Values.Add("role", userBo.Role);
                Response.Cookies.Add(httpCookie);
                FormsAuthentication.SetAuthCookie(userBo.Username, false);
                return RedirectToAction("Index", "Korisnik");
            }
            else
            {
                ModelState.AddModelError("", "Pogresan username ili password");
                return View();
            }
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(NalogBo user)
        {
            if (logregRepo.isFree(user))
            {
                logregRepo.AddUser(user);
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Useti username je zauzet");
                return View();
            }
        }

       
    }
}