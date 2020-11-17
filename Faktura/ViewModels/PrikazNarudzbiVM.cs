using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakture.ViewModels
{
	public class PrikazNarudzbiVM
	{
        public List<Row> rows { get; set; }
        
        public class Row
        {
            public string BrojNarudzbe { get; set; }
            public string KupacPodaci { get; set; }
            public DateTime Datum { get; set; }
            public string Aktivna { get; set; }
        }
    }
}
