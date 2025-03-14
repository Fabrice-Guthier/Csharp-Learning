using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tpPOO_FootballTeam_1302
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Lionel", "Messi", 10, true);
            Player player2 = new Player("Cristiano", "Ronaldo", 7, true);
            Player player3 = new Player("Kylian", "Mbappé", 7, true);
            Player player4 = new Player("Neymar", "Jr", 10, true);

            Team team1 = new Team("Paris Saint-Germain");
            team1.AddPlayer(player1);
            team1.AddPlayer(player2);
            team1.DisplayTeam();
            Console.WriteLine();

            Team team2 = new Team("FC Barcelona");
            team2.AddPlayer(player3);
            team2.AddPlayer(player4);
            team2.DisplayTeam();
            Console.WriteLine();

            player1.RedCard();
            team1.DisplayTeam();
            Console.WriteLine();
            team2.DisplayTeam();



            Console.ReadLine();
        }
}
}
