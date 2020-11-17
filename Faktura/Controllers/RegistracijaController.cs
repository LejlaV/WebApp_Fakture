using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Kino.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Fakture.Models;
using Fakture.Helper;

namespace Kino.Controllers
{
    public class RegistracijaController : Controller
    {
        public IActionResult Index()
        {
            MojDbContext db = new MojDbContext();

            RegistracijaIndexVM model = new RegistracijaIndexVM
            {
                Uloga=3
            };

            return View(model);
        }
        [ValidateAntiForgeryToken]
        public IActionResult Snimi(RegistracijaIndexVM model)
        {
            MojDbContext db = new MojDbContext();

            Korisnik noviNalog = new Korisnik();
            noviNalog.Ime = model.Ime;
            noviNalog.Prezime = model.Prezime;
            noviNalog.UserName = model.UserName;
            noviNalog.PasswordSalt = Criptography.Salt.Create();
            noviNalog.PasswordHash = Criptography.Hash.Create(model.Password,noviNalog.PasswordSalt);
            noviNalog.Email = model.Email;
            noviNalog.BrojTelefona = model.BrojTelefona;
            noviNalog.UlogaID = model.Uloga;
            noviNalog.AutorizacijskiToken = Guid.NewGuid();
            db.Korisnici.Add(noviNalog);
            db.SaveChanges();

            Kupac k = new Kupac();
            k.KorisnikID = noviNalog.KorisnikID;
            k.DatumRegistracije = DateTime.Now;
            db.Kupac.Add(k);
            db.SaveChanges();
            return Redirect("/Autentifikacija/Index");
        }
    }
    } 