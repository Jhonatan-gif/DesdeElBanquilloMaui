using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Models
{
    public class Match
    {
        public int IdMatch { get; set; }
        public DateTime MatchDate { get; set; }
        public int? HomeGoals { get; set; }
        public int? AwayGoals { get; set; }
        public MatchStatus Status { get; set; }
        public string Referee { get; set; } = "";
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int CompetitionId { get; set; }
        public int? StadiumId { get; set; }

        public static implicit operator Match(System.Text.RegularExpressions.Match v)
        {
            throw new NotImplementedException();
        }
    }
}
