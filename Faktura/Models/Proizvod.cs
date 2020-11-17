using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fakture.Models
{
	public class Proizvod
	{
		[Key]
		public int ProizvodId { get; set; }
		public string Naziv { get; set; }
		public string Sifra { get; set; }
		public decimal Cijena { get; set; }
		public string Slika { get; set; }
	}
}
