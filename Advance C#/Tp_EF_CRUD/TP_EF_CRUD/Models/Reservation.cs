using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_EF_CRUD.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Client Client { get; set; }

    }
}
