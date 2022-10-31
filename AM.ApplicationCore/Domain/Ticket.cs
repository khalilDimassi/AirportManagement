using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public double Prix { get; set; }
        public int Siege { get; set; }
        public bool VIP { get; set; }

        public int FlightID { get; set; }
        public string PassportNumber { get; set; }

        public virtual Passenger Passenger { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
