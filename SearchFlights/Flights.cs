using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFlights
{
    public class Flights : IEquatable<Flights>
    {
        public string Origin { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime DestinationTime { get; set; }
        public Decimal Price { get; set; }

        public bool Equals(Flights other)
        {
            if (other == null) return false;

            if (this.Origin == other.Origin &&
                this.DepartureTime == other.DepartureTime &&
                this.Destination == other.Destination &&
                this.DestinationTime == other.DestinationTime)
            {
                return true;
            }
            return false;
        }
    }
}
