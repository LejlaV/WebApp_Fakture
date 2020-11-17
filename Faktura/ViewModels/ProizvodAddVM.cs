using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakture.ViewModels
{
	public class ProizvodAddVM
	{
		public int ProizvodId { get; set; }
		public string Naziv { get; set; }
		public string Sifra { get; set; }
		public decimal Cijena { get; set; }
	}
}
