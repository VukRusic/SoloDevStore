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
    public class RadnikController : Controller
    {
        #region Fields
        private readonly IProizvodRepository _proizvodRepository;
        private readonly IRadnikRepository _radnikRepository; 
        #endregion

        #region Contructors
        public RadnikController()
        {
            _proizvodRepository = new ProizvodRepository();
            _radnikRepository = new RadnikRepository();
        }
        #endregion

        #region Methods
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
            ViewBag.Developers = _radnikRepository.GetAllDevelopers();
            return View();
        }

        public ActionResult GetDugovanjaByDeveloper(string username)
        {
            return Content(_radnikRepository.GetDugovanjaByDeveloper(username).ToString());
        }

        public ActionResult GetAllNonRegisteredProizvods()
        {
            return PartialView("_ListaProizvoda", _proizvodRepository.GetAllNonregisteredProizvods());
        }

        public ActionResult PayDeveloper(string username)
        {
            _radnikRepository.PayDeveloper(username);
            return RedirectToAction("Index");
        }


        public ActionResult Registruj(int id)
        {
            ProizvodBo proizvod = _proizvodRepository.GetProizvodById(id);
            ViewBag.Id = id;
            return View(proizvod);
        }

        [HttpPost]
        public ActionResult Registruj(ProizvodBo proizvod)
        {
            _proizvodRepository.RegisterProizvod(proizvod);
            return RedirectToAction("Index");
        } 
        #endregion

    }
}