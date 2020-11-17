using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fakture.Models
{
	public class NarudzbaProizvod
	{
		[Key]
		public int NarudzbaProizvodId { get; set; }
		public int NarudzbaId { get; set; }
		public Narudzba Narudzba { get; set; }
		public int ProizvodId { get; set; }
		public Proizvod Proizvod { get; set; }
		public int Kolicina { get; set; }
	}
}
