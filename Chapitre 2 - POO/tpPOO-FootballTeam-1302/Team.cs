using System;

namespace tpPOO_FootballTeam_1302
{
	public class Team
	{
		static List<Player> players = new List<Player>();

        public Team()
        {
            Name="";
            players = new List<Player>();
        }

        public Team(string initName)
        {
            Name = initName;
            players = new List<Player>();
        }

        public string Name { get; set; }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            player.RedCard();
            players.Remove(player);
        }

        public void DisplayTeam()
        {
            Console.WriteLine(Name);
            foreach (Player player in players)
            {
                player.DisplayPlayer();
            }
        }

    }
}
