using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakture.Models;

namespace Fakture.ViewModels
{
	public class AddNarudzba
	{
        public int NarudzbaId { get; set; }
        public string BrojNarudzbe { get; set; }
        public int KupacId { get; set; }
        public Kupac Kupac { get; set; }
        public DateTime Datum { get; set; }
        public bool Aktivna { get; set; }
        public int ProizvodId { get; set; }
        public Proizvod proizvod { get; set; }
        public int Kolicina { get; set; }
    }
}
