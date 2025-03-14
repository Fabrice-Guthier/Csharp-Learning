using System;

namespace tpPOO_FootballTeam_1302
{
	public class Player
	{
		public Player()
		{
			FirstName = "";
			LastName = "";
			Number = 0;
			inGame = true;
		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Number { get; set; }
		public bool inGame { get; set; }

		public Player(string initFirstName, string initLastName, int initNumber, bool initInGame)
		{
			FirstName = initFirstName;
			LastName = initLastName;
			Number = initNumber;
			inGame = initInGame;
		}

		public void DisplayPlayer()
		{
			Console.WriteLine("Le joueur numéro " + Number + " " + FirstName + " " + LastName);
		}

		public void RedCard()
        {
			inGame = false;
        }
    }
}

