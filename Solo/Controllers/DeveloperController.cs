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
        private readonly ILogRegRepository _logRegRepository = new LogRegRepository();
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
            return View(user);
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
            if (_proizvodRepository.IsMade(proizvodBo.Naziv))
            {
                _proizvodRepository.AddProizvod(proizvodBo);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Vec je unet proizvod sa unetim nazivom");
                return View("Kreiranje");
            }
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

        public ActionResult Obrisi(int id)
        {
            _proizvodRepository.DeleteProizvod(id);
            return RedirectToAction("Index");
        }

        public ActionResult PregledNaloga(string userN)
        {
            NalogBo nalog = _logRegRepository.GetNalogByName(userN);
            return View(nalog);
        }

        [HttpPost]
        public ActionResult PregledNaloga(NalogBo nalog)
        {
            _logRegRepository.Update(nalog);

            HttpCookie httpCookie = new HttpCookie("additionalCookie");
            httpCookie.Values.Add("id", nalog.Id.ToString());
            httpCookie.Values.Add("username", nalog.Username);
            httpCookie.Values.Add("password", nalog.Password);
            httpCookie.Values.Add("role", nalog.Vrsta);
            Response.Cookies.Add(httpCookie);
            FormsAuthentication.SetAuthCookie(nalog.Username, false);

            return RedirectToAction("Index");
        }
    }
}