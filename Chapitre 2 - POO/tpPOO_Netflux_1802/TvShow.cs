using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace tpPOO_Netflux_1802
{
    public class TvShow : ISelectable
    {
        public string Name { get; set; }
        public List<Episode> Episodes { get; set; }
        public TvShow(string name, List<Episode> episodes)
        {
            Name = name;
            Episodes = episodes;
        }

        public void Selected(User user)
        {
            if (user.CurrentTvShowEpisodes.ContainsKey(this))
            {
                user.CurrentTvShowEpisodes[this] += 1;
                user.Watch(Episodes[user.CurrentTvShowEpisodes[this]]);
                Console.WriteLine($"La série {Name} est en cours de visionnage. Vous en êtes à l'épisode {(user.CurrentTvShowEpisodes[this]-1)}, l'épisode {user.CurrentTvShowEpisodes[this]} va démarrer.");

            }
            else
            {
                user.CurrentTvShowEpisodes[this] = 0;
                Console.WriteLine($"La série {Name} est en cours de visionnage. Vous en êtes à l'épisode {user.CurrentTvShowEpisodes[this]}");
            }
            
        }
    }
}
