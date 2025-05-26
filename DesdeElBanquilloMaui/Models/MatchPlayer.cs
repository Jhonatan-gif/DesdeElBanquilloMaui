using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Models
{
    public class MatchPlayer
    {
        public int IdMatchPlayers { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int MinutesPlayed { get; set; }
        public bool IsStarter { get; set; }
        public int? SubstitutionMinute { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int PositionId { get; set; }
    }
}
