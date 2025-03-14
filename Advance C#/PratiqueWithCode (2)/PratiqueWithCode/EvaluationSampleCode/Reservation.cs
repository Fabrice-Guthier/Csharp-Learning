using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSampleCode
{
    public class Reservation
    {
        public User MadeBy { get; set; }

        public Reservation(User madeBy)
        {
            MadeBy = madeBy;
        }

        public bool CanBeCancelledBy(User user)
        {
            return (user.IsAdmin || MadeBy == user);
        }
    }

    // Cette classe est uniquement là pour l'implémentation du dessus
    // Pas de test à réalsier
    public class User
    {
        public bool IsAdmin { get; set; }
    }
}
