using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace tpPOO_Netflux_1802
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Episode tvShow1Episode1 = new Episode("Arcane S01E01", 44, Genre.Animation, 0);
            Episode tvShow1Episode2 = new Episode("Arcane S01E02", 45, Genre.Animation, 0);
            Episode tvShow1Episode3 = new Episode("Arcane S01E03", 43, Genre.Animation, 0);
            Episode tvShow1Episode4 = new Episode("Arcane S01E04", 44, Genre.Animation, 0);
            Episode tvShow1Episode5 = new Episode("Arcane S01E05", 47, Genre.Animation, 0);
            Episode tvShow1Episode6 = new Episode("Arcane S01E06", 44, Genre.Animation, 0);
            Episode tvShow1Episode7 = new Episode("Arcane S01E07", 45, Genre.Animation, 0);
            Episode tvShow1Episode8 = new Episode("Arcane S01E08", 45, Genre.Animation, 0);

            List<Episode> episodes = new List<Episode> { tvShow1Episode1, tvShow1Episode2, tvShow1Episode3,
            tvShow1Episode4, tvShow1Episode5, tvShow1Episode6, tvShow1Episode7, tvShow1Episode8};
            TvShow tvShow1 = new TvShow("Arcane", episodes);
            
            Episode tvShow2Episode1 = new Episode("The Witcher S01E01", 55, Genre.Fantasy, 0);
            Episode tvShow2Episode2 = new Episode("The Witcher S01E02", 56, Genre.Fantasy, 0);
            Episode tvShow2Episode3 = new Episode("The Witcher S01E03", 58, Genre.Fantasy, 0);
            Episode tvShow2Episode4 = new Episode("The Witcher S01E04", 55, Genre.Fantasy, 0);
            Episode tvShow2Episode5 = new Episode("The Witcher S01E05", 54, Genre.Fantasy, 0);
            Episode tvShow2Episode6 = new Episode("The Witcher S01E06", 59, Genre.Fantasy, 0);
            Episode tvShow2Episode7 = new Episode("The Witcher S01E07", 56, Genre.Fantasy, 0);
            Episode tvShow2Episode8 = new Episode("The Witcher S01E08", 57, Genre.Fantasy, 0);

            List<Episode> episodes2 = new List<Episode> { tvShow2Episode1, tvShow2Episode2, tvShow2Episode3,
            tvShow2Episode4, tvShow2Episode5, tvShow2Episode6, tvShow2Episode7, tvShow2Episode8};
            TvShow tvShow2 = new TvShow("The Witcher", episodes);

            Dictionary<TvShow, int> tvShows = new Dictionary<TvShow, int>();
            tvShows.Add(tvShow1, 4);
            tvShows.Add(tvShow2, 3);


            User user1 = new User("Fab", "fabrice.guthier@gmail.com", "1234", 0, tvShows);
            Content movie1 = new Movie("The Witcher", 60, Genre.Fantasy, 0, "Lauren Schmidt Hissrich");
            Content movie2 = new Movie("Berserk", 70, Genre.Animation, 0, "Kentaro Miura");
            Content movie3 = new Movie("Squid Game", 45, Genre.Thriller, 0, "Korea Man");


            movie1.Selected(user1);
            movie2.Selected(user1);
            movie3.Selected(user1);
            user1.PrintWatchtime();
            Console.WriteLine();
            user1.PrintNumberOfViews(movie1);
            user1.PrintNumberOfViews(movie2);
            user1.PrintNumberOfViews(movie1);
            Console.WriteLine();
            user1.Select(tvShow1);
            user1.Select(tvShow2);
            Console.WriteLine();
            user1.PrintWatchtime();
            Console.WriteLine();


            Console.ReadLine();
        }
    }
}