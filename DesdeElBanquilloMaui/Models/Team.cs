using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Models
{
    public class Team
    {
        public int IdTeam { get; set; }
        public string Name { get; set; } = "";
        public string City { get; set; } = "";
        public DateTime FoundedDate { get; set; }
        public int CompetitionId { get; set; }
        public int CountryId { get; set; }
        public int LeagueId { get; set; }
    }
}
