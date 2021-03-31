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
        #region Fields
        private readonly ILogRegRepository logregRepo; 
        #endregion

        #region Constructors
        public LogRegController()
        {
            logregRepo = new LogRegRepository();
        }
        #endregion

        #region Methods
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserBo user)
        {
            if (logregRepo.isValid(user))
            {
                UserBo userBo = logregRepo.GetUserByName(user.Username);

                HttpCookie httpCookie = new HttpCookie("additionalCookie");
                httpCookie.Values.Add("id", userBo.Id.ToString());
                httpCookie.Values.Add("username", userBo.Username);
                httpCookie.Values.Add("password", userBo.Password);
                httpCookie.Values.Add("role", userBo.Role);
                Response.Cookies.Add(httpCookie);
                FormsAuthentication.SetAuthCookie(userBo.Username, false);

                if (userBo.Role == "Korisnik")
                {
                    return RedirectToAction("Index", "Korisnik");
                }
                else if (userBo.Role == "Developer")
                {
                    return RedirectToAction("Index", "Developer");
                }
                else
                {
                    return RedirectToAction("Index", "Radnik");
                }
            }
            else
            {
                ModelState.AddModelError("", "Pogresan username ili password");
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
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
                ModelState.AddModelError("", "Uneti username je zauzet");
                return View();
            }
        }

        public ActionResult Help()
        {
            return View();
        } 
        #endregion

    }
}