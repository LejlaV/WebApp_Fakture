using Fakture.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakture.ViewModels
{
	public class FakturaIndexVM
	{
        public int FakturaId { get; set; }
        public string BrojFakture { get; set; }
        public DateTime Datum { get; set; }
        public int KupacId { get; set; }
        public Kupac Kupac { get; set; }
        public bool Zakljucen { get; set; }
        public decimal IznosBezPdv { get; set; }
        public decimal IznosSaPdv { get; set; }
        public decimal IznosSaPdvBiH { get; set; }
        public decimal IznosSaPdvHr { get; set; }
        public int NarudzbaId { get; set; }
        public Narudzba Narudzba { get; set; }
        public string kupacPodaci { get; set; }
        public int BrojNarucenihProizvoda { get; set; }
        public int PdvId { get; set; }
        public List<SelectListItem> pdv { get; set; }
    }
}
