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
        private readonly IProizvodRepository _proizvodRepository = new ProizvodRepository();
        private readonly IRecenzijaRepository _recenzijaRepository = new RecenzijaRepository();
        private readonly ILogRegRepository _logRegRepository = new LogRegRepository();

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

        public ActionResult GetAvgOcenaByProizvodId(int id)
        {
            return Content(_recenzijaRepository.GetAvgRecenzijaByProizvodId(id));
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

        public ActionResult Recenzija(int id)
        {
            ViewBag.Proizvod = id;
            return View();
        }

        [HttpPost]
        public ActionResult Recenzija(RecenzijaBo recenzija)
        {
            ViewBag.Proizvod = recenzija.IdProizvoda;
            if (_recenzijaRepository.IsMade(recenzija))
            {
                _recenzijaRepository.AddRecenzija(recenzija);
                return RedirectToAction("Detalji", new { id = ViewBag.Proizvod });
            }
            else
            {
                ModelState.AddModelError("", "Vec ste uneli recenziju za ovaj proizvod");
                return View();
            }
        }

        public ActionResult Kupi(int idProzivoda)
        {
            string username = User.Identity.Name;
            int id = _logRegRepository.GetIdByName(username);

            if (_proizvodRepository.IsPurchased(id, idProzivoda))
            {
                string odobrenje = _proizvodRepository.BuyProduct(username, idProzivoda);
                NalogBo TrenutniNalog = _logRegRepository.GetNalogByName(username);


                if (odobrenje == "Uspeh")
                {
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[15];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    var finalString = new String(stringChars);
                    ViewBag.Poruka = "http://" + finalString;
                    return View(TrenutniNalog);
                }
                else
                {
                    ViewBag.Poruka = "Nemate dovoljno novca na racunu!";
                    return View(TrenutniNalog);
                }
            }
            else
            {
                ViewBag.Poruka = "Vec ste kupili ovaj proizvod";
                NalogBo TrenutniNalog = _logRegRepository.GetNalogByName(username);
                return View(TrenutniNalog);
            }

        }


    }
}