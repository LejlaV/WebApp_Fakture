using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakture.Helper;
using Fakture.Models;
using Fakture.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fakture.Controllers
{
    public class AutentifikacijaController : Controller
    {
        public IActionResult Index()
        {
            MojDbContext db = new MojDbContext();
            return View(new LoginVM()
            {
                ZapamtiPassword=true
            });
        }
       public  IActionResult Login(LoginVM input)
       {
            MojDbContext db = new MojDbContext();

            Korisnik korisnik = db.Korisnici.Include(x => x.Uloga).SingleOrDefault(x => x.UserName == input.Username);

            //if (!(korisnik.PasswordHash == Criptography.Hash.Create(input.Password, korisnik.PasswordSalt)))
            //{
            //    ViewData["error-poruka"] = "pogrešan username ili password";
            //    return View("Index", input);
            //}

            HttpContext.SetLogiraniKorisnik(korisnik);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}