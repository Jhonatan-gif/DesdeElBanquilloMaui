using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Models
{
    public class Federation
    {
        public int IdFederation { get; set; }
        public string Name { get; set; } = "";
        public string Acronym { get; set; } = "";
        public DateTime EstablishedDate { get; set; }
        public int IdCountry { get; set; }
    }
}
