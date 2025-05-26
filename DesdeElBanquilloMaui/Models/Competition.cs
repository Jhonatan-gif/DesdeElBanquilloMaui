using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Models
{
    public class Competition
    {
        public int IdCompetition { get; set; }
        public string Name { get; set; } = "";
        public string Season { get; set; } = "";
        public int CountryId { get; set; }
        public int FederationId { get; set; }
    }
}
