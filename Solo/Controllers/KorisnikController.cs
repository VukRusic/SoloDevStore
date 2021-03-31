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
                ProizvodBo proizvodKupljeni = _proizvodRepository.GetProizvodById(idProzivoda);


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
                    ViewBag.Result = true;
                    ViewBag.Poruka = "http://" + finalString;
                    ViewBag.Developer = _proizvodRepository.GetDeveloperByProizvodId(idProzivoda);
                    ViewBag.KupljeniProzivod = proizvodKupljeni.Id;
                    return View(TrenutniNalog);
                }
                else
                {
                    ViewBag.Result = false;
                    ViewBag.Poruka = "Nemate dovoljno novca na racunu";
                    return View(TrenutniNalog);
                }
            }
            else
            {
                ViewBag.Result = false;
                ViewBag.Poruka = "Vec ste kupili izabrani proizvod";
                NalogBo TrenutniNalog = _logRegRepository.GetNalogByName(username);
                return View(TrenutniNalog);
            }

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


        public ActionResult Uplatnica(int id,string username)
        {
            var chars = "0123456789";
            var stringChars = new char[10];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            var chars2 = "0123456789";
            var stringChars2 = new char[2];
            var random2 = new Random();

            for (int i = 0; i < stringChars2.Length; i++)
            {
                stringChars2[i] = chars2[random2.Next(chars2.Length)];
            }

            var finalString2 = new String(stringChars2);
            NalogBo nalog= _logRegRepository.GetNalogByName(username);
            
            ProizvodBo proizvod = _proizvodRepository.GetProizvodById(id);
            ViewBag.Cena = proizvod.Cena;
            ViewBag.Korisnik = nalog.Ime + " " + nalog.Prezime;
            ViewBag.Developer = _proizvodRepository.GetDeveloperByProizvodId(id);
            ViewBag.ModelBroj = finalString2;
            ViewBag.PozivNaBroj = finalString;
            return View();
        }


    }
}