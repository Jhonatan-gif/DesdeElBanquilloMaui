using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Models
{
    public class Season
    {
        public int IdSeason { get; set; }
        public string Name { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCurrent { get; set; }
        public int TotalMatchdays { get; set; }
        public int LeagueId { get; set; }
    }
}
