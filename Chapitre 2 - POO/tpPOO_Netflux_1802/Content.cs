using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace tpPOO_Netflux_1802
{
    public abstract class Content
	{
		public string Name { get; set; }
		public int Duration { get; set; }
		public Genre Genre { get; set; }
		public int NumberOfViews { get; set; }

		public Content(string name, int duration, Genre genre, int numberOfViews)
        {
            Name = name;
            Duration = duration;
            Genre = genre;
            NumberOfViews = numberOfViews;
        }
    }
}
