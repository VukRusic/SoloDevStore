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
    public class KorisnikController : Controller
    {
        private readonly IProizvod _proizvodRepository = new ProizvodRepository();
        private readonly IRecenzija _recenzijaRepository = new RecenzijaRepository();
        

        //[Authorize(Roles = "Korisnik")]
        public ActionResult Index()
        {
            HttpCookie httpCookie = Request.Cookies["additionalCookie"];
            UserBo user = new UserBo
            {
                Username = httpCookie.Values["username"],
                Password = httpCookie.Values["password"],
                Role = httpCookie.Values["role"]
            };
            ViewBag.Zanr = _proizvodRepository.GetAll().Select(t => t.Zanr).Distinct().ToList();
            return View(user);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","LogReg");
        }

        public ActionResult GetAllProizvods()
        {
            return PartialView("_ListaProizvoda", _proizvodRepository.GetAll());
        }

        public ActionResult GetProizvodBySelectedZanr(string zanr)
        {
            if (zanr == "")
            {
                return PartialView("_ListaProizvoda", _proizvodRepository.GetAll());
            }
            else
            {
                return PartialView("_ListaProizvoda", _proizvodRepository.GetProizvodByZanr(zanr));
            }
        }

        public ActionResult GetProzivodByEnteredName(string ime)
        {
            if (ime == "")
            {
                return PartialView("_ListaProizvoda", _proizvodRepository.GetAll());
            }
            else
            {
                return PartialView("_ListaProizvoda", _proizvodRepository.GetProzivodByIme(ime));
            }
        }

        public ActionResult Detalji(int id)
        {
            ProizvodBo proizvod = _proizvodRepository.GetProizvodById(id);
            ViewBag.Proizvod = id;
            ViewBag.Developer = _proizvodRepository.GetDeveloperByProizvodId(id);
            return View(proizvod);
        }

        public ActionResult GetAllRecenzijasByProizvodId(int id)
        {
            return PartialView("_ListaRecenzija", _recenzijaRepository.GetRecenzijasByProizvodId(id));
        }

        public ActionResult Recenzija()
        {
            return View();
        }
    }
}