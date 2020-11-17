using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakture.ViewModels
{
	public class IzaberiPDV
	{
		public int PdvId { get; set; }
		public List<SelectListItem> pdv { get; set; }
		public int narudbzaId { get; set; }
		public int novaFakturaId { get; set; }
	}
}
