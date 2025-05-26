using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Models
{
    public class League
    {
        public int IdLeague { get; set; }
        public string Name { get; set; } = "";
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public int CountryId { get; set; }
    }

}
