using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fakture.Models;
using Fakture.ViewModels;
using Fakture.Helper;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Fakture.Controllers
{
    public class AdminController : Controller
    {
        //private readonly IWebHostEnvironment hostingEnvironment;

        private readonly ILogger<AdminController> _logger;
        MojDbContext db = new MojDbContext();

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProizvodiIndex()
        {
            ProizvodiIndexVM model = new ProizvodiIndexVM();

            model.rows = db.Proizvod.Select(x => new ProizvodiIndexVM.Row()
            {
                ProizvodId=x.ProizvodId,
                Naziv = x.Naziv,
                Cijena = x.Cijena,
                Sifra = x.Sifra,
            }).ToList();
            return View(model);
        }

        public IActionResult ProizvodAdd()
        {
            return View();
        }

        public IActionResult ProizvodSave(ProizvodAddVM model)
        {
            Proizvod noviProizvod = new Proizvod()
            {
                Naziv = model.Naziv,
                Cijena = model.Cijena,
                Sifra = model.Sifra,
            };
            db.Proizvod.Add(noviProizvod);
            db.SaveChanges();
            return RedirectToAction(nameof(ProizvodiIndex));
        }

        public IActionResult ProizvodEdit(int proizvodId)
        {
            Proizvod proizvod = db.Proizvod.Find(proizvodId);
            ProizvodAddVM model = new ProizvodAddVM()
            {
                ProizvodId=proizvod.ProizvodId,
                Naziv=proizvod.Naziv,
                Cijena = proizvod.Cijena,
                Sifra = proizvod.Sifra,
            };
            return View(model);
        }

        public IActionResult ProizvodSaveEdit(ProizvodAddVM model)
        {
            Proizvod proizvod = db.Proizvod.Find(model.ProizvodId);

            proizvod.Naziv = model.Naziv;
            proizvod.Cijena = model.Cijena;
            proizvod.Sifra = model.Sifra;
            db.SaveChanges();
            return RedirectToAction(nameof(ProizvodiIndex));
        }

        public IActionResult Obrisi(int proizvodId)
        {
            Proizvod proizvod = db.Proizvod.Find(proizvodId);
            db.Proizvod.Remove(proizvod);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction(nameof(ProizvodiIndex));
        }
        public IActionResult PrikazNarudzbi()
        {
            PrikazNarudzbiVM model = new PrikazNarudzbiVM();

            model.rows = db.Narudzba.Select(x => new PrikazNarudzbiVM.Row()
            {
                BrojNarudzbe = x.BrojNarudzbe,
                KupacPodaci = x.Kupac.Korisnik.Ime + " " + x.Kupac.Korisnik.Prezime,
                Datum = x.Datum,
                Aktivna = x.Aktivna ? "DA" : "NE"
            }).ToList();

            return View(model);
        }
    }
}
