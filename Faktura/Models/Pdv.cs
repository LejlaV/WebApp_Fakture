using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fakture.Models
{
	public class Pdv
	{
		[Key]
		public int PdvId { get; set; }
		public string Drzava { get; set; }
		public decimal Vrijednost { get; set; }
	}
}
