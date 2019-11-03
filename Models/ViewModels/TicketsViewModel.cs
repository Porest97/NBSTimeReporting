using NBSTimeReporting.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.ViewModels
{
    public class TicketsViewModel
    {
        public List<Ticket> Tickets { get; internal set; }
    }
}
