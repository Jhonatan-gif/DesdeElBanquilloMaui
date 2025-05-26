using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Models
{
    public class Stadium
    {
        public int IdStadium { get; set; }
        public string Name { get; set; } = "";
        public DateTime FoundedDate { get; set; }
        public int Capacity { get; set; }
        public int TeamId { get; set; }
    }
}
