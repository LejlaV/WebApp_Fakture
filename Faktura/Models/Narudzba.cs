using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fakture.Models
{
	public class Narudzba
	{
        [Key]
        public int NarudzbaId { get; set; }
        public string BrojNarudzbe { get; set; }
        public int KupacId { get; set; }
        public Kupac Kupac { get; set; }
        public DateTime Datum { get; set; }
        public bool Aktivna { get; set; }
    }
}
