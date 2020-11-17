using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakture.Models;

namespace Fakture.ViewModels
{
	public class NarudzbeIndexVM
	{
		public List<Row> rows { get; set; }
		public string KupacPodaci { get; set; }
		public double BrojNarucenihProizvoda { get; set; }

		public class Row
		{
			public DateTime Datum { get; set; }
			public string Aktivna { get; set; }
			public string ProizvodNaziv { get; set; }
			public int NarudzbaId { get; set; }
			
		}
	}
}
