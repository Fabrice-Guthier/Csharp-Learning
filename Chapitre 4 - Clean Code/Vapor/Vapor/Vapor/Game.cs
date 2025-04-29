using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vapor
{
    public class Game : IDownloadable
    {
        public string Name { get; set; }
        public virtual float Price { get; set; }
        public int YearReleased { get; set; }
        public GameStudio GameStudio { get; set; }
        public virtual int Discount { get; set; } //expressed as a percentage
        public GameSave GameSave { get; set; }

        public Game(string name, float price, int yearReleased, GameStudio gameStudio, int discount = 0)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            YearReleased = yearReleased;
            GameStudio = gameStudio ?? throw new ArgumentNullException(nameof(gameStudio));

            GameStudio.GamesReleased.Add(this);
            Discount = discount;
            GameSave = new GameSave();
        }

        public override string ToString()
        {
            return Name + " by " + GameStudio + " " + GetCurrentPrice() + "€";
        }

        public virtual float GetCurrentPrice()
        {
            return Price - Price * Discount / 100;
        }

        public void Install()
        {
            Download();
            Console.WriteLine("Installing the game");
            GameSave.Download();
        }

        public void LaunchGame()
        {
            GameSave.Update();
            Console.WriteLine("Launching the game");
        }

        public void CloseGame()
        {
            Console.WriteLine("Closing the game");
            GameSave.Upload();
        }

        public void Download()
        {
            Console.WriteLine("*** Test Download ***");
        }

        public void Update()
        {
            Console.WriteLine("*** Test Update ***");
        }

        public void Upload()
        {
            //you cannot upload a game as a user
        }
    }
}
