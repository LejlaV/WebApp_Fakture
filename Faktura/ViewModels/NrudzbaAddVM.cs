using Fakture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakture.ViewModels
{
	public class NarudzbaAddVM
	{
        public int NarudzbaId { get; set; }
        public string BrojNarudzbe { get; set; }
        public int KupacId { get; set; }
        public Kupac Kupac { get; set; }
        public DateTime Datum { get; set; }
        public bool Aktivna { get; set; }
    }
}
