using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Nombre { get; set; } = "";
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}
