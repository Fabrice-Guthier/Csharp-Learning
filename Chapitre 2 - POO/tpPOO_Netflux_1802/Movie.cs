using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace tpPOO_Netflux_1802
{
	public class Movie : Content, ISelectable
	{
		public string Director { get; set; }
        public Movie(string name, int duration, Genre genre, int numberOfViews, string director) : base(name, duration, genre, numberOfViews)
        {
            Director = director;
        }

        public void Selected(User user)
        {
            user.Watch(this);
            Console.WriteLine($"Le film {Name} est en cours de visionnage.");
        }

    }
}
