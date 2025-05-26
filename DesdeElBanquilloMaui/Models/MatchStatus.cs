using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesdeElBanquilloMaui.Models
{
    public enum MatchStatus
    {
        Scheduled = 0,
        Live = 1,
        Finished = 2,
        Suspended = 3,
        Cancelled = 4,
        Postponed = 5
    }
}
