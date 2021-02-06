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
    [Authorize]
    public class DeveloperController : Controller
    {
        private readonly IProizvodRepository _proizvodRepository = new ProizvodRepository();
        public ActionResult Index()
        {
            HttpCookie httpCookie = Request.Cookies["additionalCookie"];
            UserBo user = new UserBo
            {
                Id = int.Parse(httpCookie.Values["id"]),
                Username = httpCookie.Values["username"],
                Password = httpCookie.Values["password"],
                Role = httpCookie.Values["role"]
            };
            ViewBag.Id = user.Id;
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "LogReg");
        }

        public ActionResult GetRegisteredProizvodsByDeveloper(int id)
        {
            return PartialView("_ListaProizvoda", _proizvodRepository.GetRegisteredProizvodsByDeveloperId(id));
        }

        public ActionResult AddProizvod(int id)
        {
            ViewBag.Id = id;
            return View("Kreiranje");
        }
        [HttpPost]
        public ActionResult AddProizvod(ProizvodBo proizvodBo)
        {
            _proizvodRepository.AddProizvod(proizvodBo);
            return RedirectToAction("Index");
        }

        public ActionResult GetNonregisteredProizvods(int id)
        {
            return PartialView("_ListaProizvoda", _proizvodRepository.GetNonegisteredProizvods(id));
        }

        public ActionResult Izmeni(int id)
        {
            ViewBag.Id = id;
            ProizvodBo proizvod = _proizvodRepository.GetProizvodById(id);
            return View(proizvod);
        }

        [HttpPost]
        public ActionResult Izmeni(ProizvodBo proizvod)
        {
            _proizvodRepository.Update(proizvod);
            return RedirectToAction("Index");
        }
    }
}