using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Models
{
    public class Player
    {
        public int IdPlayer { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public int JerseyNumber { get; set; }
        public decimal MarketValue { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public int TeamId { get; set; }
        public int PositionId { get; set; }
        public int CountryId { get; set; }
    }
}
