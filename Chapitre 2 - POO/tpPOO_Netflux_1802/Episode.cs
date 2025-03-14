using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace tpPOO_Netflux_1802
{
	public class Episode : Content
    {
		public Episode(string name, int duration, Genre genre, int numberOfViews) : base(name, duration, genre, numberOfViews)
        {
			
		}
	}
}