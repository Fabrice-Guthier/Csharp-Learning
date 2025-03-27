using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordShop_Entity_Full.Models
{
    class Reservation
    {
        public string Name { get; set; }
        public int ReservationId { get; set; }
        public int AnimalId { get; set; }
        public int ClientId { get; set; }

        public Animal Animal { get; set; }

        public Client Client { get; set; }

        public int NumeroReservation { get; set; }
    }
}
