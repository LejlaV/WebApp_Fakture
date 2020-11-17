using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fakture.Models;
using Fakture.Helper;
using Fakture.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fakture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MojDbContext db = new MojDbContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();

            if (k.Uloga.Naziv.Contains("administrator"))
            {
                ProizvodiIndexVM proizvodiIndexVM = new ProizvodiIndexVM();

                proizvodiIndexVM.rows = db.Proizvod.Select(x => new ProizvodiIndexVM.Row()
                {
                    ProizvodId = x.ProizvodId,
                    Naziv = x.Naziv,
                    Cijena = x.Cijena,
                    Sifra = x.Sifra,
                }).ToList();
                return View("ProizvodiIndex", proizvodiIndexVM);
            }

            ProizvodiIndexVM model = new ProizvodiIndexVM();
            model.KupacId = db.Kupac.Where(x => x.KorisnikID == k.KorisnikID).Select(x => x.KupacID).FirstOrDefault();
            model.rows = db.Proizvod.Select(x => new ProizvodiIndexVM.Row()
            {
                ProizvodId = x.ProizvodId,
                Naziv = x.Naziv,
                Cijena = x.Cijena,
                Sifra = x.Sifra,
            }).ToList();

            return View(model);
        }
        public IActionResult AddNarudzba(int proizvodId)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            Kupac kupac = db.Kupac.Find(k.KorisnikID);

            AddNarudzba model = new AddNarudzba()
            {
                ProizvodId = proizvodId
            };
            return View(model);
        }
        public IActionResult SaveNarudzba(AddNarudzba model)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            Kupac kupac = db.Kupac.Where(x => x.KorisnikID == k.KorisnikID).FirstOrDefault();

            var listaNarudzbi = db.Narudzba.ToList();
            bool narudzbaPostoji = false;
            foreach (var item in listaNarudzbi)
            {
                if (item.KupacId == kupac.KupacID && item.Aktivna == true)
                {
                    NarudzbaProizvod npr = new NarudzbaProizvod();
                    npr.NarudzbaId = item.NarudzbaId;
                    npr.ProizvodId = model.ProizvodId;
                    npr.Kolicina = model.Kolicina;
                    narudzbaPostoji = true;
                    db.NarudzbaProizvod.Update(npr);
                    db.SaveChanges();
                }
            }

            if (narudzbaPostoji == false)
            {
                Random r = new Random();
                Narudzba novaNarudzba = new Narudzba()
                {
                    Datum = DateTime.Now,
                    BrojNarudzbe = (r.Next() + DateTime.Now.Year).ToString(),
                    KupacId = kupac.KupacID,
                    Aktivna = true,
                };

                db.Narudzba.Add(novaNarudzba);
                db.SaveChanges();

                NarudzbaProizvod np = new NarudzbaProizvod();

                np.NarudzbaId = novaNarudzba.NarudzbaId;
                np.ProizvodId = model.ProizvodId;
                np.Kolicina = model.Kolicina;
                db.NarudzbaProizvod.Add(np);
                db.SaveChanges();
            }
            return Redirect("/Home/NarudzbeIndex?kupacId=" + kupac.KupacID);
        }
        public IActionResult NarudzbeIndex(int kupacId)
        {
            Kupac k = db.Kupac.Find(kupacId);

            NarudzbeIndexVM model = new NarudzbeIndexVM();

            model.KupacPodaci = db.Kupac.Where(x => x.KupacID == kupacId)
                .Select(x => x.Korisnik.Ime + " " + x.Korisnik.Prezime).FirstOrDefault();

            model.rows = db.Narudzba.Where(x => x.KupacId == kupacId).OrderByDescending(x => x.Datum)
                .Select(x => new NarudzbeIndexVM.Row()
                {
                    Aktivna = x.Aktivna ? "DA" : "NE",
                    Datum = x.Datum,
                    NarudzbaId = x.NarudzbaId,
                }).ToList();

            return View(model);
        }
        public IActionResult IzaberiPDV(int narudzbaId)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            Kupac kupac = db.Kupac.Where(x => x.KorisnikID == k.KorisnikID).FirstOrDefault();

            Narudzba narudzba = db.Narudzba.Find(narudzbaId);
            Faktura novaFaktura = new Faktura();
            Random r = new Random();
            novaFaktura.BrojFakture = (r.Next() + DateTime.Now.Year).ToString();
            novaFaktura.NarudzbaId = narudzbaId;
            novaFaktura.KupacId = kupac.KupacID;
            novaFaktura.Datum = DateTime.Now;
            novaFaktura.Zakljucen = true;

            narudzba.Aktivna = false;
            db.Narudzba.Update(narudzba);
            db.SaveChanges();
            db.Faktura.Add(novaFaktura);
            db.SaveChanges();

            IzaberiPDV model = new IzaberiPDV()
            {
                pdv = db.Pdv.Select(x => new SelectListItem()
                {
                    Value = x.PdvId.ToString(),
                    Text = $"{x.Drzava},{x.Vrijednost}"
                }).ToList()
            };
            model.narudbzaId = narudzbaId;
            model.novaFakturaId = novaFaktura.FakturaId;
            return View(model);
        }

        public IActionResult SaveFaktura(IzaberiPDV model)
        {
            Faktura faktura = db.Faktura.Find(model.novaFakturaId);
            
            var listaNarudzbi = db.NarudzbaProizvod.ToList();

            foreach (var item in listaNarudzbi)
            {
                if (item.NarudzbaId == model.narudbzaId)
                {
                    var listaProizvoda = db.Proizvod.ToList();
                    foreach (var p in listaProizvoda)
                    {
                        if (p.ProizvodId == item.ProizvodId)
                        {
                            faktura.IznosBezPdv += p.Cijena * item.Kolicina;
                            
                            if (model.PdvId == 1)
                            {
                                faktura.IznosSaPdv = p.Cijena * item.Kolicina + p.Cijena*item.Kolicina*Convert.ToDecimal(0.17);
                                faktura.PdvId = 1;
                            }
                            else
                            {
                                faktura.IznosSaPdv += p.Cijena * item.Kolicina + p.Cijena * item.Kolicina * Convert.ToDecimal(0.25);
                                faktura.PdvId = 2;
                            }
                        }
                    }
                }
            }
            db.Faktura.Update(faktura);
            db.SaveChanges();
            return Redirect("/Home/PrikazFakture?fakturaId=" + faktura.FakturaId);
        }
        public IActionResult PrikazFakture(int fakturaId)
        {
            Faktura faktura = db.Faktura.Find(fakturaId);
            FakturaIndexVM model = new FakturaIndexVM()
            {
                FakturaId = faktura.FakturaId,
                BrojFakture = faktura.BrojFakture,
                Datum = faktura.Datum,
                IznosBezPdv = faktura.IznosBezPdv,
                IznosSaPdv = faktura.IznosSaPdv
            };
            Kupac k = db.Kupac.Find(faktura.KupacId);
            var listaKorisnika = db.Korisnici.ToList();
            foreach (var item in listaKorisnika)
            {
                if (item.KorisnikID == k.KorisnikID)
                {
                    model.kupacPodaci = k.Korisnik.Ime + " " + k.Korisnik.Prezime;
                }
            }
            var listaNarudzbi = db.Narudzba.ToList();
            foreach (var item in listaNarudzbi)
            {
                if (item.NarudzbaId == faktura.NarudzbaId)
                {
                    var listaNarudzbeProizvodi = db.NarudzbaProizvod.ToList();
                    foreach (var x in listaNarudzbeProizvodi)
                    {
                        if (x.NarudzbaId == item.NarudzbaId)
                        {
                            model.BrojNarucenihProizvoda += x.Kolicina;
                        }
                    }
                }
            }
            return View(model);
        }
        public IActionResult PrikazFaktureZaNarudzbu(int narudzbaId)
        {
            FakturaIndexVM model = new FakturaIndexVM();

            var listaFaktura = db.Faktura.ToList();
            foreach (var item in listaFaktura)
            {
                if (item.NarudzbaId == narudzbaId)
                {
                    model.NarudzbaId = item.NarudzbaId;
                    model.BrojFakture = item.BrojFakture;
                    model.Datum = item.Datum;
                    model.IznosSaPdv = item.IznosSaPdv;
                    model.IznosBezPdv = item.IznosBezPdv;
                    model.kupacPodaci = db.Kupac.Where(x => x.KupacID == item.KupacId).Select(x => x.Korisnik.Ime + " " + x.Korisnik.Prezime).FirstOrDefault();

                    var listaNarudzbeProizvodi = db.NarudzbaProizvod.ToList();
                    foreach (var x in listaNarudzbeProizvodi)
                    {
                        if (x.NarudzbaId == item.NarudzbaId)
                        {
                            model.BrojNarucenihProizvoda += x.Kolicina;
                        }
                    }
                }
            }
            return View("PrikazFakture", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
